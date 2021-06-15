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
    public class LecturerController: Controller
    {
        private readonly ILecturerService _lecturerService;
        private readonly IStudentService _studentService;
        private readonly IAdminService _adminService;
        private readonly ILogger<LecturerController> _logger;
        private readonly Mapper _mapper;

        public LecturerController(ILecturerService lecturerService, IStudentService studentService, IAdminService adminService, ILogger<LecturerController> logger)
        {
            _lecturerService = lecturerService;
            _studentService = studentService;
            _adminService = adminService;
            _logger = logger;
            var congig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<LecturerDTO, LecturerModel>();
                cfg.CreateMap<CourseLecturerDTO, CourseLecturerModel>();
                cfg.CreateMap<SubjectDTO, SubjectModel>();
                cfg.CreateMap<SemesterDTO, SemesterModel>();
                cfg.CreateMap<StudentDTO, StudentModel>();
                cfg.CreateMap<MarkDTO, MarkLecturerModel>();
            });
            _mapper = new Mapper(congig);
        }

        public IActionResult ShowAll(int page = 1, int size = 10)
        {
            IList<LecturerDTO> lecturers = _lecturerService.ShowAllLecturer();
            
            return View(PaginatedList<LecturerModel>.CreateList(
                _mapper.Map<IList<LecturerDTO>, List<LecturerModel>>(lecturers).AsQueryable(), page, size));
        }

        public IActionResult ShowCourseOfLecture(int id)
        {
            var courses = _mapper.Map<IList<CourseLecturerDTO>, LinkedList<CourseLecturerModel>>(_lecturerService.ShowAllCourses(id));
            var subjects =  _mapper.Map<IList<SubjectDTO>, LinkedList<SubjectModel>>(_adminService.ShowAllSubjects());
            var semesters = _mapper.Map<IList<SemesterDTO>, LinkedList<SemesterModel>>(_adminService.ShowAllSemesters());
            _logger.LogInformation($"Show all course of lecturer {id}");
            ViewData["semester"] = semesters;
            ViewData["subject"] = subjects;
            ViewData["idLecturer"] = id;
            return View(courses);
        }
        
        public IActionResult ShowFollowingStudent(FollowingStudentOnCourseModel followingStudentOnCourseModel)
        {
            var studentsDTO = _lecturerService.ShowAllFollowingStudentsOnCourse(new LecturerAndCourseDTO()
            {IdCourse = followingStudentOnCourseModel.IdCourse, IdLecturer = followingStudentOnCourseModel.IdLecturer});
            if (studentsDTO == null)
                return Redirect("~/Lecturer/ShowAll/" );
            var students = _mapper.Map<IList<StudentDTO>, LinkedList<StudentModel>>(studentsDTO);
            _logger.LogInformation($"Show all student folowing on course {followingStudentOnCourseModel.IdCourse}");
            ViewData["idCourse"] = followingStudentOnCourseModel.IdCourse;
            ViewData["idLecturer"] = followingStudentOnCourseModel.IdLecturer;
            return View(students);
        }

        public IActionResult ShowMarksFollowingStudent(StudentOfCourseModel studentOfCourseModel)
        {
            FollowStudentDTO followStudentDto = new FollowStudentDTO() {IdCourse = studentOfCourseModel.IdCourse, IdStudent = studentOfCourseModel.IdStudent};
            var m = _studentService.ShowMarksCourseByIdStudent(followStudentDto);
            var marks = _mapper.Map<IList<MarkDTO>, LinkedList<MarkLecturerModel>>(m);
            _logger.LogInformation($"Show all mark of student:{studentOfCourseModel.IdStudent} following on course:{studentOfCourseModel.IdCourse}");
            ViewData["course"] = studentOfCourseModel.IdCourse;
            ViewData["student"] = studentOfCourseModel.IdStudent;
            return View(marks);
        }

        [HttpPost]
        public IActionResult PutMark(InputMarkModel inputMarkModel)
        {
            var mark = new InputMarkDTO()
            {
                 Course = inputMarkModel.Course, Mark = inputMarkModel.Mark,
                IdStudent = inputMarkModel.IdStudent
            };
            if (_lecturerService.AddMarkStudent(mark))
                _logger.LogInformation($"Put marks:{inputMarkModel.Mark} student:{inputMarkModel.IdStudent} on course:{inputMarkModel.Course}");
            return Redirect($"~/Lecturer/ShowMarksFollowingStudent/?idCourse={inputMarkModel.Course}&idStudent={inputMarkModel.IdStudent}");
        }

        public IActionResult AddNewFollowingStudent(FollowingStudentOnCourseModel followingStudentOnCourseModel)
        {
            var students = _studentService.ShowAllStudents();
            var list = _mapper.Map<IList<StudentDTO>, LinkedList<StudentModel>>(students);
            _logger.LogInformation($"Add new following student{followingStudentOnCourseModel.IdCourse} on course{followingStudentOnCourseModel.IdCourse}");
            ViewData["idCourse"] = followingStudentOnCourseModel.IdCourse;
            ViewData["idLecturer"] = followingStudentOnCourseModel.IdLecturer;
            return View(list);
        }

        [HttpPost]
        public IActionResult AddNewLecturer(string name, int experience)
        {
            _adminService.AddNewLecturer(name, experience);
            return Redirect("~/Lecturer/ShowAll");
        }

        [HttpPost]
        public IActionResult EditLecturer(int id, string name, int experience)
        {
            if(_adminService.ChangeLecturerById(id, name, experience))
                return StatusCode(200);
            return StatusCode(404);
        }

        [HttpPost]
        public IActionResult AddCourse(NewCourseModel newCourseModel)
        {
            _lecturerService.AddNewCourse(new NewCourseDTO()
            {
                IdLecturer = newCourseModel.IdLecturer, IdSemester = newCourseModel.IdSemester,
                IdSubject = newCourseModel.IdSubject
            });
            return Redirect("~/Lecturer/ShowCourseOfLecture/" + newCourseModel.IdLecturer);
        }

        [HttpPost]
        public IActionResult EditCourse(NewCourseModel newCourseModel)
        {
            if (_lecturerService.ChangeCourse(new UpdateCourseDTO()
            {
                Id = newCourseModel.Id,
                IdLecturer = newCourseModel.IdLecturer,
                IdSemester = newCourseModel.IdSemester,
                IdSubject = newCourseModel.IdSemester
            }))
                return StatusCode(200);
            _logger.LogWarning($"Error in editor course");
            return StatusCode(404);
        }

        [HttpPost]
        public IActionResult DeleteMark(int id, int idCourse, int idStudent)
        {
            _lecturerService.DeleteMark(id);
            return Redirect($"~/Lecturer/ShowMarksFollowingStudent/?idStudent={idStudent}&idCourse={idCourse}");
        }

        [HttpPost]
        public IActionResult AddStudent(int idStudent, int idCourse, int idLecturer)
        {
            _lecturerService.AddNewStudentToCourse(new FollowingStudentDTO() {IdStudent = idStudent, IdCourse = idCourse, IdLecture = idLecturer});
            return Redirect($"~/Lecturer/ShowFollowingStudent/?idCourse={idCourse}&idLecturer={idLecturer}");
        }

        [HttpPost]
        public IActionResult DeleteFollowingStudent(int idStudent, int idCourse, int idLecturer)
        {
            _lecturerService.DeleteFollowingStudent(idStudent);
            return Redirect("~/Lecturer/ShowFollowingStudent/?idCourse=" + idCourse + "&idLecturer=" + idLecturer);
        }
        
        public IActionResult DeleteCourse(int idCourse, int idLecturer)
        {
            _lecturerService.DeleteCourse(idCourse);
            return Redirect($"~/Lecturer/ShowCourseOfLecture/{idLecturer}");
        }
    }
}