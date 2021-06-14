using System.Collections.Generic;
using System.Linq;
using DTO;
using Faculty.Entities;
using Faculty.Interfaces;
using Interfaces;

namespace Services
{
    public class CourseService: ICourseService
    {
        private readonly IRepository<Course> _courseRepository;

        public CourseService(IRepository<Course> courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public IList<FullCourseDTO> ShowCourses()
        {
            IList<Course> courses =
                _courseRepository.FindInclude(c => c.Id != 0, course => course.Lecturer, course => course.Semester, course => course.Subject).ToList();
            IList<FullCourseDTO> fullCourses = new List<FullCourseDTO>();
            foreach (var course in courses)
            {
                fullCourses.Add(new FullCourseDTO(){Id = course.Id, Lecturer = course.Lecturer.Name, Name = course.Subject.Name, To = course.Semester.To, With = course.Semester.With, Experience = course.Lecturer.Experience, IdSubject = course.Subject.Id});
            }

            return fullCourses;
        }
    }
}