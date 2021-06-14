using System.Collections.Generic;
using System.IO;
using DTO;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Model;
using WebApplication.Utils;
using ClosedXML.Excel;

namespace WebApplication
{
    public class CourseController: Controller
    {
        private readonly ICourseService _courseService;
        private readonly IAdminService _adminService;

        public CourseController(ICourseService courseService, IAdminService adminService)
        {
            _courseService = courseService;
            _adminService = adminService;
        }

        [HttpGet]
        public IActionResult ShowAll()
        {
            IList<FullCourseDTO> fullCourses = _courseService.ShowCourses();
            var courses = new List<InformationAboutCourseModel>();
            foreach (var course in fullCourses)
            {
                courses.Add(new InformationAboutCourseModel()
                {
                    Id = course.Id, Lecturer = course.Lecturer, Name = course.Name, To = course.To, With = course.With
                });
            }
            var subjectDTO = _adminService.ShowAllSubjects();
            var subjects = new List<SubjectModel>();
            foreach (var subject in subjectDTO)
            {
                subjects.Add(new SubjectModel() {Id = subject.Id, Name = subject.Name});
            }

            ViewData["expUp"] = 0;
            ViewData["expDown"] = 0;
            ViewData["to"] = null;
            ViewData["with"] = null; 
            ViewData["subject"] = subjects;
            ViewData["name"] = null;
            ViewData["select"] = 0;
            return View(courses);
        }

        [HttpPost]
        public IActionResult Filter(FilterModel filterModel)
        {
            var filter = new Filter(filterModel);
            var list = filter.GetResult(_courseService.ShowCourses());
            var subjectDTO = _adminService.ShowAllSubjects();
            var subjects = new List<SubjectModel>();
            foreach (var subject in subjectDTO)
            {
                subjects.Add(new SubjectModel() {Id = subject.Id, Name = subject.Name});
            }
            var courses = new List<InformationAboutCourseModel>();
            foreach (var course in list)
            {
                courses.Add(new InformationAboutCourseModel()
                {
                    Id = course.Id, Lecturer = course.Lecturer, Name = course.Name, To = course.To, With = course.With
                });
            }
            
            ViewData["expUp"] = filterModel.ExperienceUp;
            ViewData["expDown"] = filterModel.ExperienceDown;
            ViewData["to"] = filterModel.To;
            ViewData["with"] = filterModel.With; 
            ViewData["subject"] = subjects;
            ViewData["name"] = filterModel.Name;
            ViewData["select"] = filterModel.IdSubject;
            return View("ShowAll", courses);
        }

        public IActionResult Download(FilterModel filterModel)
        {
            var filter = new Filter(filterModel);
            var result = filter.GetResult(_courseService.ShowCourses());
            using (var workbook = new XLWorkbook())
            {
                //_logger.LogInformation($"Saving xlsx file for items");

                var worksheet = workbook.Worksheets.Add("Items");
                worksheet.Cell("A1").Value = "Id";
                worksheet.Cell("B1").Value = "Name of subject";
                worksheet.Cell("C1").Value = "Name of lecturer";
                worksheet.Cell("D1").Value = "Begin";
                worksheet.Cell("E1").Value = "End";

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
                    
                }

                var rowo = worksheet.Row(2);
                rowo.Cell(7).Value = result.Count;

                var cd = new System.Net.Mime.ContentDisposition
                {
                    FileName = "Items.xlsx",
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