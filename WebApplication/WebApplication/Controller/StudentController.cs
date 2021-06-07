using System.Collections.Generic;
using DTO;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace WebApplication
{
    public class StudentController: Controller
    {
        private IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        
        public IActionResult ShowAll()
        {
            LinkedList<StudentModel> studentModels = new LinkedList<StudentModel>();
            foreach (var student in _studentService.ShowAllStudents())
            {
                studentModels.AddLast(new StudentModel(){Id = student.Id, Name = student.Name});
            }
            ViewData["Students"] = studentModels;
            return View();
        }

        public IActionResult ShowCourseOfStudent(int id)
        {
            var courses = _studentService.ShowAllCoursesOfStudent(id);
            if (courses == null || courses.Count == 0)
                return Redirect("~/Student/ShowAll");
            LinkedList<CourseModel> courseModels = new LinkedList<CourseModel>();
            foreach (var course in courses)
            {
                courseModels.AddLast(new CourseModel()
                    {Id = course.Id, Name = course.Name, NameLecturer = course.NameLecturer});
            }
            return View(courseModels);
        }

        public IActionResult ShowSessionMarksOfStudent(int id)
        {
            var marks = _studentService.ShowSessionMarksIdStudent(id);
            if (marks == null)
                return Redirect("~/Student/ShowAll");
            LinkedList<SessionMarkModel> sessionMarkModels = new LinkedList<SessionMarkModel>();
            foreach (var mark in marks)
            {
                sessionMarkModels.AddLast(new SessionMarkModel()
                    {Id = mark.Id, Mark = mark.Mark, To = mark.To, With = mark.With, NameCourse = mark.NameCourse});
            }
            return View(sessionMarkModels);
        }

        public IActionResult ShowMarksOfStudentCourse(FollowStudentModel followStudentModel)
        {
            FollowStudentDTO followingStudentDto = new FollowStudentDTO()
                {IdCourse = followStudentModel.IdCourse, IdStudent = followStudentModel.IdStudent};
            var marksDTO = _studentService.ShowMarksCourseByIdStudent(followingStudentDto);
            LinkedList<MarkModel> marks = new LinkedList<MarkModel>();
            foreach (var mark in marksDTO)
            {
                marks.AddLast(new MarkModel() {Mark = mark.Mark, Date = mark.Date});
            }

            return View();
        }
    }
}