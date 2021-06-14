using System;
using System.Collections.Generic;
using DTO;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace WebApplication
{
    public class AdminController: Controller
    {
        private IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        public IActionResult ShowSubject()
        {
            IList<SubjectDTO> subjects = _adminService.ShowAllSubjects();
            LinkedList<SubjectModel> subjectModels = new LinkedList<SubjectModel>();
            foreach (var subjectVar in subjects)
            {
                subjectModels.AddLast(new SubjectModel() {Id = subjectVar.Id, Name = subjectVar.Name});
            }

            return View(subjectModels);
        }

        public IActionResult ShowSemester()
        {
            IList<SemesterDTO> semesters = _adminService.ShowAllSemesters();
            LinkedList<SemesterModel> subjectModels = new LinkedList<SemesterModel>();
            foreach (var s in semesters)
            {
                subjectModels.AddLast(new SemesterModel() {Id = s.Id, With = s.With, To = s.To});
            }

            return View(subjectModels);
        }

        [HttpPost]
        public IActionResult EditSubject(SubjectModel subjectModel)
        {
            if (_adminService.ChangeSubject(new SubjectDTO() {Id = subjectModel.Id, Name = subjectModel.Name}))
                return StatusCode(200);
            return StatusCode(404);
        }

        [HttpPost]
        public IActionResult AddSubject(string name)
        {
            _adminService.AddNewSubject(name);
            return Redirect("~/Admin/ShowSubject/");
        }

        [HttpPost]
        public IActionResult AddSemester(DateTime to, DateTime with)
        {
            _adminService.AddNewSemester(with, to);
            return Redirect("~/Admin/ShowSemester/");
        }
        
        [HttpPost]
        public IActionResult EditSemester(SemesterModel semesterModel)
        {
            if (_adminService.ChangeSemester(new SemesterDTO()
                {Id = semesterModel.Id, To = semesterModel.To, With = semesterModel.With}))
                return StatusCode(200);
            return StatusCode(404);
        }
    }
}