using System.Collections.Generic;
using DTO;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace WebApplication
{
    public class LecturerController: Controller
    {
        private readonly ILecturerService _lecturerService;
        private readonly IStudentService _studentService;
        private readonly IAdminService _adminService;

        public LecturerController(ILecturerService lecturerService, IStudentService studentService, IAdminService adminService)
        {
            _lecturerService = lecturerService;
            _studentService = studentService;
            _adminService = adminService;
        }

        public IActionResult ShowAll()
        {
            IList<LecturerDTO> lecturers = _lecturerService.ShowAllLecturer();
            LinkedList<LecturerModel> lecturerModels = new LinkedList<LecturerModel>();
            foreach (var lec in lecturers)
            {
                lecturerModels.AddLast(new LecturerModel() {Name = lec.Name, Experience = lec.Experience, IdLecturer = lec.IdLecturer});
            }

            return View(lecturerModels);
        }

        public IActionResult ShowCourseOfLecture(int id)
        {
            var courseDTO = _lecturerService.ShowAllCourses(id);
            if (courseDTO == null || courseDTO.Count == 0)
                return Redirect("~/Lecturer/ShowAll/");
            var courses = new LinkedList<CourseLecturerModel>();
            foreach (var course in courseDTO)
            {
                courses.AddLast(new CourseLecturerModel()
                    {Id = course.Id, Name = course.Name, To = course.To, With = course.With});
            }

            var subjectDTO = _adminService.ShowAllSubjects();
            var subjects = new LinkedList<SubjectModel>();
            foreach (var subject in subjectDTO)
            {
                subjects.AddLast(new SubjectModel() {Id = subject.Id, Name = subject.Name});
            }

            var semesterDTO = _adminService.ShowAllSemesters();
            var semesters = new LinkedList<SemesterModel>();
            foreach (var semester in semesterDTO)
            {
                semesters.AddLast(new SemesterModel() {Id = semester.Id, To = semester.To, With = semester.With});
            }

            ViewData["semester"] = semesters;
            ViewData["subject"] = subjects;
            ViewData["idLecturer"] = id;
            return View(courses);
        }
        
        public IActionResult ShowFollowingStudent(FollowingStudentOnCourseModel followingStudentOnCourseModel)
        {
            var lecturer = new LecturerAndCourseDTO()
            {
                IdCourse = followingStudentOnCourseModel.IdCourse, IdLecturer = followingStudentOnCourseModel.IdLecturer
            };
            var studentsDTO = _lecturerService.ShowAllFollowingStudentsOnCourse(lecturer);
            if (studentsDTO == null)
                return Redirect("~/Lecturer/ShowAll/" );
            LinkedList<StudentModel> students = new LinkedList<StudentModel>();
            foreach (var student in studentsDTO)
            {
                students.AddLast(new StudentModel() {Id = student.Id, Name = student.Name});
            }
            ViewData["idCourse"] = lecturer.IdCourse;
            ViewData["idLecturer"] = lecturer.IdLecturer;
            return View(students);
        }

        public IActionResult ShowMarksFollowingStudent(StudentOfCourseModel studentOfCourseModel)
        {
            FollowStudentDTO followStudentDto = new FollowStudentDTO() {IdCourse = studentOfCourseModel.IdCourse, IdStudent = studentOfCourseModel.IdStudent};
            IList<MarkDTO> markDtos = _studentService.ShowMarksCourseByIdStudent(followStudentDto);
            LinkedList<MarkLecturerModel> markLecturerModels = new LinkedList<MarkLecturerModel>();
            foreach (var mark in markDtos)
            {
                markLecturerModels.AddLast(new MarkLecturerModel() {Id = mark.Id, Date = mark.Date, Mark = mark.Mark});
            }

            ViewData["course"] = studentOfCourseModel.IdCourse;
            ViewData["student"] = studentOfCourseModel.IdStudent;
            return View(markLecturerModels);
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
                ;
            return Redirect($"~/Lecturer/ShowMarksFollowingStudent/?idCourse={inputMarkModel.Course}&idStudent={inputMarkModel.IdStudent}");
        }

        public IActionResult AddNewFollowingStudent(FollowingStudentOnCourseModel followingStudentOnCourseModel)
        {
            var students = _studentService.ShowAllStudents();
            LinkedList<StudentModel> list = new LinkedList<StudentModel>();
            foreach (var student in students)
            {
                list.AddLast(new StudentModel() {Id = student.Id, Name = student.Name});
            }

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
    }
}