using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using DTO;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Model;
using WebApplication.Utils;
using ClosedXML.Excel;
using Microsoft.Extensions.Logging;

namespace WebApplication
{
    public class CourseController: Controller
    {
        private readonly ICourseService _courseService;
        private readonly IAdminService _adminService;
        private readonly ILogger<CourseController> _logger;
        private readonly Mapper _mapper;

        public CourseController(ICourseService courseService, IAdminService adminService, ILogger<CourseController> logger)
        {
            _courseService = courseService;
            _adminService = adminService;
            _logger = logger;
            var congig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SubjectDTO, SubjectModel>();
                cfg.CreateMap<FullCourseDTO, InformationAboutCourseModel>();
            });
            _mapper = new Mapper(congig);
        }

        [HttpGet]
        public IActionResult ShowAll(FilterModel filterModel = null ,int page = 1, int size = 10)
        {
            List<InformationAboutCourseModel> courses;
            if (filterModel != null)
            {
                var list = new Filter(filterModel).GetResult(_courseService.ShowCourses());
                courses = _mapper.Map<IList<FullCourseDTO>, List<InformationAboutCourseModel>>(list);
            }
            else
            {
                courses = _mapper.Map<IList<FullCourseDTO>, List<InformationAboutCourseModel>>(_courseService.ShowCourses());
            }
            
            var subjects = _mapper.Map<IList<SubjectDTO>, List<SubjectModel>>(_adminService.ShowAllSubjects());
            
            ViewData["expUp"] = filterModel?.ExperienceUp ?? 0;
            ViewData["expDown"] = filterModel?.ExperienceDown ?? 0;
            ViewData["to"] = filterModel?.To ?? null;
            ViewData["with"] = filterModel?.With ?? null;
            ViewData["subject"] = subjects;
            ViewData["name"] = filterModel?.Name ?? null;
            ViewData["select"] = filterModel?.IdSubject ?? 0;
            return View(PaginatedList<InformationAboutCourseModel>.CreateList(courses.AsQueryable(), page, size));
        }

        [HttpPost]
        public IActionResult Filter(FilterModel filterModel, int page = 1, int size = 10)
        {
            var list = new Filter(filterModel).GetResult(_courseService.ShowCourses());
            var subjects = _mapper.Map<IList<SubjectDTO>, List<SubjectModel>>(_adminService.ShowAllSubjects());
            var courses = _mapper.Map<IList<FullCourseDTO>, List<InformationAboutCourseModel>>(list);
            
            ViewData["expUp"] = filterModel.ExperienceUp;
            ViewData["expDown"] = filterModel.ExperienceDown;
            ViewData["to"] = filterModel.To;
            ViewData["with"] = filterModel.With; 
            ViewData["subject"] = subjects;
            ViewData["name"] = filterModel.Name;
            ViewData["select"] = filterModel.IdSubject;
            return View("ShowAll", PaginatedList<InformationAboutCourseModel>.CreateList(courses.AsQueryable(), page, size));
        }

        public IActionResult Download(FilterModel filterModel)
        {
            var filter = new Filter(filterModel);
            var result = filter.GetResult(_courseService.ShowCourses());
            using (var workbook = new XLWorkbook())
            {
                _logger.LogInformation($"Saving xlsx file of information about courses");

                var worksheet = workbook.Worksheets.Add("Course");
                worksheet.Cell("A1").Value = "Id";
                worksheet.Cell("B1").Value = "Name of subject";
                worksheet.Cell("C1").Value = "Name of lecturer";
                worksheet.Cell("D1").Value = "Begin";
                worksheet.Cell("E1").Value = "End";
                worksheet.Cell("F1").Value = "Count students";

                worksheet.Cell("G1").Value = "Total Amount";
                worksheet.Cell("H1").Value = "Total Value";
                    
                int row = 1;
                foreach (var item in result)
                {
                    var rowObj = worksheet.Row(++row);
                    rowObj.Cell(1).Value = item.Id;
                    rowObj.Cell(2).Value = item.Name;
                    rowObj.Cell(3).Value = item.Lecturer;

                    rowObj.Cell(4).Value = item.With;
                    rowObj.Cell(5).Value = item.To;
                    rowObj.Cell(6).Value = item.Count;
                    
                }
                
                worksheet.Cell("H2").FormulaA1 = $"=SUM($F$2:$F${row})";
                worksheet.Cell("G2").FormulaA1 = $"=COUNTIF($F$2:$F${row};\"0\")";
                var cd = new System.Net.Mime.ContentDisposition
                {
                    FileName = "Course.xlsx",
                    Inline = false,
                };
                Response.Headers.Add("Content-Disposition", cd.ToString());

                using (MemoryStream stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "course.xlsx");
                }
            }   
        }
        
    }
}