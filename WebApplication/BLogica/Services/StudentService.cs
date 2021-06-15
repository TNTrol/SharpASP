

using System.Collections.Generic;
using System.Linq;
using DTO;
using Faculty.Entities;
using Faculty.Interfaces;
using Faculty.Repositories;
using Interfaces;

namespace Services
{
    public class StudentService: IStudentService
    {
        private readonly IRepository<Student> _studentRepository;
        private readonly IRepository<FollowingStudent> _followingStudentRepository;
        private readonly IRepository<Course> _courseRepository;

        public StudentService(IRepository<Student> studentRepository, IRepository<FollowingStudent> followingStudentRepository,IRepository<Course> courseRepository)
        {
            _studentRepository = studentRepository;
            _followingStudentRepository = followingStudentRepository;
            _courseRepository = courseRepository;
        }

        public IList<MarkDTO> ShowMarksCourseByIdStudent(FollowStudentDTO followStudent)
        {
            List<MarkDTO> markdto = new List<MarkDTO>();
            Student student = _studentRepository.Get(followStudent.IdStudent);
            Course course = _courseRepository.Get(followStudent.IdCourse);
            if (student == null || course == null)
                return markdto;
            var marks = _followingStudentRepository
                .FindInclude(fs => fs.Student == student && fs.Course == course, fsp => fsp.Marks).First();
            
            foreach (var mark in marks.Marks)
                markdto.Add(new MarkDTO(){Date = mark.Date, Mark = mark.MarkStudent, Id = mark.Id});
            return markdto;
        }

        public IList<SessionMarkDTO> ShowSessionMarksIdStudent(int idStudent)
        {
            Student student = _studentRepository.Get(idStudent);
            if (student == null)
                return null;
            var sessionMark = _followingStudentRepository.FindInclude(fs => fs.Student.Id == idStudent && fs.SessionMarks != null, fsp => fsp.SessionMarks, fsp => fsp.Course.Semester, fsp=>fsp.Course.Subject).ToList();
            List<SessionMarkDTO> sessionMarks = new List<SessionMarkDTO>();
            foreach (var mark in sessionMark)
            {
                sessionMarks.Add(new SessionMarkDTO(){Id = mark.SessionMarks.Id, NameCourse = mark.Course.Subject.Name, Mark = mark.SessionMarks.Mark, To = mark.Course.Semester.To,With = mark.Course.Semester.With});
            }
            return sessionMarks;
        }

        public IList<CourseDTO> ShowAllCoursesOfStudent(int idStudent)
        {
            List<CourseDTO> courseDtos = new List<CourseDTO>();
            Student student = _studentRepository.Get(idStudent);
            if (student == null)
                return courseDtos;
            var courseLecturer = _followingStudentRepository.FindInclude(fs => fs.Student == student, fs =>  fs.Course.Lecturer, fs => fs.Course.Subject)
                .Select(fs => fs.Course ).ToList();
            foreach (var course in courseLecturer)
                courseDtos.Add(new CourseDTO(){Id = course.Id, Name = course.Subject.Name, NameLecturer = course.Lecturer.Name, IdStudent = idStudent});
            return courseDtos;
        }

        public IList<StudentDTO> ShowAllStudents()
        {
            IList<Student> students = _studentRepository.GetAll().ToList();
            IList<StudentDTO> studentDtos = new List<StudentDTO>();
            foreach (var student in students)
            {
                studentDtos.Add(new StudentDTO(){Id = student.Id, Name = student.Name});
            }

            return studentDtos;
        }
        
        public IList<StudentDTO> ShowAllWithoutStudentsOfCourse(int idCourse)
        {
            IList<Student> students = _followingStudentRepository
                .FindInclude(s => s.Course.Id != idCourse, s => s.Student, s => s.Course).Select(s => s.Student).Distinct().ToList();
            IList<StudentDTO> studentDtos = new List<StudentDTO>();
            foreach (var student in students)
            {
                studentDtos.Add(new StudentDTO(){Id = student.Id, Name = student.Name});
            }

            return studentDtos;
        }
        

    }
}