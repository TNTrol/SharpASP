

using System;
using System.Collections.Generic;
using System.Linq;
using DTO;
using Faculty.Entities;
using Faculty.Interfaces;
using Faculty.Repositories;
using Interfaces;

namespace Services
{
    public class LecturerService: ILecturerService
    {
        private readonly IRepository<Lecturer> _lecturerRepository;
        private readonly IRepository<Student> _studentRepository;
        private readonly IRepository<FollowingStudent> _followingStudentRepository;
        private readonly IRepository<Mark> _markRepository;
        private readonly IRepository<Course> _courseRepository;

        public LecturerService(IRepository<Lecturer> lecturerRepository, 
                IRepository<Student> studentRepository, 
                IRepository<FollowingStudent> followingStudentRepository,
                IRepository<Mark> markRepository,
                IRepository<Course> courseRepository)
        {
            _lecturerRepository = lecturerRepository;
            _studentRepository = studentRepository;
            _followingStudentRepository = followingStudentRepository;
            _markRepository = markRepository;
            _courseRepository = courseRepository;
        }

        public IList<CourseDTO> ShowAllCourses(int idLecturer)
        {
            Lecturer lecturer = _lecturerRepository.Get(idLecturer);
            if (lecturer == null)
                return null;
            List<Course> list = _courseRepository.FindInclude(c => c.Id == idLecturer, c => c.Subject).ToList();
            List<CourseDTO> courses = new List<CourseDTO>();
            foreach(Course course in list)
                courses.Add(new CourseDTO(){Id = course.Id, Name = course.Subject.Name, NameLecturer = lecturer.Name});
            return courses;

        }

        public bool AddMarkStudent(InputMarkDTO inputMark)
        {
            Lecturer lecturer = _lecturerRepository.Get(inputMark.Lecture);
            if (lecturer == null)
                return false;
            Student student = _studentRepository.Get(inputMark.IdStudent);
            Course course = _courseRepository.Find(c => c.Id == inputMark.Course && c.Lecturer == lecturer).First();
            if (course == null)
                return false;
            FollowingStudent followingStudent =
                _followingStudentRepository.Find(fs => fs.Student == student && fs.Course == course ).First();
            if (followingStudent == null)
                return false;
            Mark eMark = new Mark {Student = followingStudent, MarkStudent = inputMark.Mark, Date = DateTime.Now};
            _markRepository.Create(eMark);
            return true;
        }

        public IList<StudentDTO> ShowAllFollowingStudentsOnCourse(LecturerDTO lecturerDto)
        {
            Lecturer lecturer = _lecturerRepository.Get(lecturerDto.IdLecturer);
            if (lecturer == null)
                return null;
            Course course = _courseRepository.Find(c => c.Id == lecturerDto.IdCourse && c.Lecturer == lecturer).First();
            if (course == null)
                return null;
            var students = _followingStudentRepository.FindInclude(fs => fs.Course == course, fsp => fsp.Student)
                .Select(f => f.Student).ToList();
            List<StudentDTO> outStudents = new List<StudentDTO>();
            foreach(Student student in students)
                outStudents.Add(new StudentDTO(){Id = student.Id, Name = student.Name});
            return outStudents;
        }

        public bool AddNewStudentToCourse(FollowingStudentDTO newStudent)
        {
            Lecturer lecturer = _lecturerRepository.Get(newStudent.IdLecture);
            if (lecturer == null)
                return false;
            Course course = _courseRepository.Find(c => c.Id == newStudent.IdCourse && c.Lecturer == lecturer).First();
            Student student = _studentRepository.Get(newStudent.IdStudent);
            if (student == null || course == null)
                return false;
            FollowingStudent followingStudent = _followingStudentRepository.Find(s => s.Student == student && s.Course == course).First();
            if (followingStudent != null)
                return false;
            _followingStudentRepository.Create(new FollowingStudent() { Course = course, Student = student, Marks = new List<Mark>()});
            return true;
        }

        public IList<LecturerDTO> ShowAllLecturer()
        {
            var lec = _lecturerRepository.GetAll().ToList();
            List<LecturerDTO> lecturers = new List<LecturerDTO>();
            foreach (var lecturer in lec)
            {
                lecturers.Add(new LecturerDTO() {IdCourse = lecturer.Id, IdLecturer = lecturer.Id, Experience = lecturer.Experience, Name = lecturer.Name});
            }
            return lecturers;
        }

    }
}