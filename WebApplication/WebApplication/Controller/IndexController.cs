using Microsoft.AspNetCore.Mvc;

namespace WebApplication
{
    public class IndexController:Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}