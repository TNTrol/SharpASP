using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DTO;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model;
using WebApplication.Utils;

namespace WebApplication
{
    public class StudentController: Controller
    {
        private IStudentService _studentService;
        private IAdminService _adminService;
        private readonly ILogger<StudentController> _logger;
        private readonly Mapper _mapper;

        public StudentController(IStudentService studentService, IAdminService adminService, ILogger<StudentController> logger)
        {
            _studentService = studentService;
            _adminService = adminService;
            _logger = logger;
            var congig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<StudentDTO, StudentModel>();
                cfg.CreateMap<CourseDTO, CourseModel>();
                cfg.CreateMap<SessionMarkDTO, SessionMarkModel>();
                cfg.CreateMap<MarkDTO, MarkModel>();
            });
            _mapper = new Mapper(congig);
        }
        
        public IActionResult ShowAll(int page = 1, int size = 10)
        {
            _logger.LogInformation("Show all students");
            IList<StudentModel> st =  _mapper.Map<IList<StudentDTO>, List<StudentModel>>(_studentService.ShowAllStudents());
            return View(PaginatedList<StudentModel>.CreateList(st.AsQueryable(), page, size));
        }

        public IActionResult ShowCourseOfStudent(int id)
        {
            var courses = _studentService.ShowAllCoursesOfStudent(id);
            if (courses == null || courses.Count == 0)
                return Redirect("~/Student/ShowAll");
            return View( _mapper.Map<IList<CourseDTO>, LinkedList<CourseModel>>(courses));
        }

        public IActionResult ShowSessionMarksOfStudent(int id)
        {
            var marks = _studentService.ShowSessionMarksIdStudent(id);
            if (marks == null)
                return Redirect("~/Student/ShowAll");
            return View( _mapper.Map<IList<SessionMarkDTO>, LinkedList<SessionMarkModel>>(marks));
        }

        public IActionResult ShowMarksOfStudentCourse(FollowStudentModel followStudentModel)
        {
            var marks = _studentService.ShowMarksCourseByIdStudent(new FollowStudentDTO()
                {IdCourse = followStudentModel.IdCourse, IdStudent = followStudentModel.IdStudent});
            if (marks == null || marks.Count == 0)
                return Redirect($"~/Student/ShowCourseOfStudent/{followStudentModel.IdStudent}");
            return View(_mapper.Map<IList<MarkDTO>, LinkedList<MarkModel>>(marks));
        }

        [HttpPost]
        public IActionResult AddNewStudent(string name)
        {
            _adminService.AddNewStudent(name);
            return Redirect("~/Student/ShowAll");
        }

        [HttpPost]
        public IActionResult EditStudent(string name, int id)
        {
            if(_adminService.ChangeStudentById(id, name))
                return StatusCode(200);
            return StatusCode(404);
        }

    }
}