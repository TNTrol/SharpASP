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

        public LecturerController(ILecturerService lecturerService)
        {
            _lecturerService = lecturerService;
        }

        public IActionResult ShowAllLecturer()
        {
            IList<LecturerDTO> lecturers = _lecturerService.ShowAllLecturer();
            LinkedList<LecturerModel> lecturerModels = new LinkedList<LecturerModel>();
            foreach (var lec in lecturers)
            {
                lecturerModels.AddLast(new LecturerModel())
            }
        }
    }
}