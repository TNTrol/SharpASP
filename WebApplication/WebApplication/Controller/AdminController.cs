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
    public class AdminController: Controller
    {
        private IAdminService _adminService;
        private readonly ILogger<AdminController> _logger;
        private readonly Mapper _mapper;
        
        public AdminController(IAdminService adminService, ILogger<AdminController> logger)
        {
            _adminService = adminService;
            _logger = logger;
            var congig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SubjectDTO, SubjectModel>();
                cfg.CreateMap<SemesterDTO, SemesterModel>();
            });
            _mapper = new Mapper(congig);
        }

        public IActionResult ShowSubject(int page = 1, int size = 10)
        {
            var subjectModels =
                _mapper.Map<IList<SubjectDTO>, LinkedList<SubjectModel>>(_adminService.ShowAllSubjects());
            _logger.LogInformation("Showing all subjects");
            return View(PaginatedList<SubjectModel>.CreateList(subjectModels.AsQueryable(), page, size));
        }

        public IActionResult ShowSemester(int page = 1, int size = 10)
        {
            var subjectModels =
                _mapper.Map<IList<SemesterDTO>, List<SemesterModel>>(_adminService.ShowAllSemesters());
            _logger.LogInformation("Showing all semesters");
            return View(PaginatedList<SemesterModel>.CreateList(subjectModels.AsQueryable(), page, size));
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