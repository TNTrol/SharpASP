

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
        private readonly IRepository<Semester> _semesterRepository;
        private readonly IRepository<Subject> _subjectRepository;

        public LecturerService(IRepository<Lecturer> lecturerRepository, 
                IRepository<Student> studentRepository, 
                IRepository<FollowingStudent> followingStudentRepository,
                IRepository<Mark> markRepository,
                IRepository<Course> courseRepository,
                IRepository<Semester> semesterRepository,
                IRepository<Subject> subjectRepository)
        {
            _lecturerRepository = lecturerRepository;
            _studentRepository = studentRepository;
            _followingStudentRepository = followingStudentRepository;
            _markRepository = markRepository;
            _courseRepository = courseRepository;
            _semesterRepository = semesterRepository;
            _subjectRepository = subjectRepository;
        }

        public IList<CourseLecturerDTO> ShowAllCourses(int idLecturer)
        {
            Lecturer lecturer = _lecturerRepository.Get(idLecturer);
            if (lecturer == null)
                return null;
            List<Course> list = _courseRepository.FindInclude(c => c.Lecturer.Id == idLecturer, c => c.Subject, c2 => c2.Semester, c=> c.Lecturer).ToList();
            List<CourseLecturerDTO> courses = new List<CourseLecturerDTO>();
            foreach(Course course in list)
                courses.Add(new CourseLecturerDTO(){Id = course.Id, Name = course.Subject.Name, To = course.Semester.To, With = course.Semester.With});
            return courses;

        }

        public bool AddMarkStudent(InputMarkDTO inputMark)
        {
            // Lecturer lecturer = _lecturerRepository.Get(inputMark.Lecture);
            // if (lecturer == null)
            //     return false;
            Student student = _studentRepository.Get(inputMark.IdStudent);
            Course course = _courseRepository.Find(c => c.Id == inputMark.Course ).First();
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

        public IList<StudentDTO> ShowAllFollowingStudentsOnCourse(LecturerAndCourseDTO lecturerDto)
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
            FollowingStudent followingStudent = _followingStudentRepository
                .Find(s => s.Student == student && s.Course == course).FirstOrDefault(); 
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
                lecturers.Add(new LecturerDTO() {IdLecturer = lecturer.Id, Experience = lecturer.Experience, Name = lecturer.Name});
            }
            return lecturers;
        }

        public bool AddNewCourse(NewCourseDTO newCourseDto)
        {
            var course = CheckCourse(newCourseDto);
            if (!course.Item1)
                return false;
            Course course1 = new Course() {Lecturer = course.Item3, Subject = course.Item4, Semester = course.Item2};
            _courseRepository.Create(course1);
            return true;
        }

        private (bool, Semester, Lecturer, Subject) CheckCourse(NewCourseDTO newCourseDto)
        {
            var course = _courseRepository
                .FindInclude(
                    c => c.Semester.Id == newCourseDto.IdSemester && c.Lecturer.Id == newCourseDto.IdLecturer &&
                         c.Subject.Id == newCourseDto.IdSubject, c => c.Semester, c => c.Lecturer, c => c.Subject).FirstOrDefault();
            if (course != null)
                return (false, null, null, null);
            var lecturer = _lecturerRepository.Get(newCourseDto.IdLecturer);
            var semester = _semesterRepository.Get(newCourseDto.IdSemester);
            var subject = _subjectRepository.Get(newCourseDto.IdSubject);
            if (lecturer == null || semester == null || subject == null)
                return (false, null, null, null);
            return (true, semester, lecturer, subject);
        }

        public bool ChangeCourse(UpdateCourseDTO updateCourseDto)
        {
            var course = _courseRepository.Get(updateCourseDto.Id);
            if (course == null)
                return false;
            var courseTuple = CheckCourse(new NewCourseDTO()
            {
                IdLecturer = updateCourseDto.IdLecturer, IdSemester = updateCourseDto.IdSemester,
                IdSubject = updateCourseDto.IdSubject
            });
            if (!courseTuple.Item1)
                return false;
            _courseRepository.Update(new Course(){Id = updateCourseDto.Id, Lecturer = courseTuple.Item3, Semester = courseTuple.Item2, Subject = courseTuple.Item4});
            return true;
        }

        public void DeleteMark(int id)
        {
            _markRepository.Delete(id);
        }

        public bool DeleteFollowingStudent(int id)
        {
            var student = _followingStudentRepository
                .FindInclude(s => s.Student.Id == id, s => s.Student, s => s.Marks, s => s.SessionMarks)
                .FirstOrDefault();
            foreach (var mark in student.Marks.ToList())
            {
                _markRepository.Delete(mark.Id);
            }
            _followingStudentRepository.Delete(student.Id);
            return true;
        }
    }
}