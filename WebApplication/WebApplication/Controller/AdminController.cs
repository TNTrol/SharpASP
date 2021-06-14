using System;
using System.Collections.Generic;
using DTO;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model;

namespace WebApplication
{
    public class AdminController: Controller
    {
        private IAdminService _adminService;
        private readonly ILogger<AdminController> _logger;

        public AdminController(IAdminService adminService, ILogger<AdminController> logger)
        {
            _adminService = adminService;
            _logger = logger;
        }

        public IActionResult ShowSubject()
        {
            IList<SubjectDTO> subjects = _adminService.ShowAllSubjects();
            LinkedList<SubjectModel> subjectModels = new LinkedList<SubjectModel>();
            foreach (var subjectVar in subjects)
            {
                subjectModels.AddLast(new SubjectModel() {Id = subjectVar.Id, Name = subjectVar.Name});
            }
            _logger.LogInformation("Showing all subjects");
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
            _logger.LogInformation("Showing all semesters");
            return View(subjectModels);
        }

        [HttpPost]
        public IActionResult EditSubject(SubjectModel subjectModel)
        {
            if (_adminService.ChangeSubject(new SubjectDTO() {Id = subjectModel.Id, Name = subjectModel.Name}))
                return StatusCode(200);
            _logger.LogWarning($"Bad post edit subject");
            return StatusCode(404);
        }

        [HttpPost]
        public IActionResult AddSubject(string name)
        {
            _adminService.AddNewSubject(name);
            _logger.LogInformation($"Add subject with name: {name}");
            return Redirect("~/Admin/ShowSubject/");
        }

        [HttpPost]
        public IActionResult AddSemester(DateTime to, DateTime with)
        {
            _adminService.AddNewSemester(with, to);
            _logger.LogInformation($"Add semester with {with} to {to}");
            return Redirect("~/Admin/ShowSemester/");
        }
        
        [HttpPost]
        public IActionResult EditSemester(SemesterModel semesterModel)
        {
            if (_adminService.ChangeSemester(new SemesterDTO()
                {Id = semesterModel.Id, To = semesterModel.To, With = semesterModel.With}))
                return StatusCode(200);
            _logger.LogWarning($"Bad post edit semester");
            return StatusCode(404);
        }
    }
}