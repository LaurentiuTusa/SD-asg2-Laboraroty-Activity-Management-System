using System.Diagnostics;
using Asg2.Models;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

using Asg2.BLL.Services.Contracts;
using Asg2.DAL.Models;

namespace Asg2.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        /*        private readonly ILogger<HomeController> _logger;

                public HomeController(ILogger<HomeController> logger)
                {
                    _logger = logger;
                }*/

        private readonly IStudentService _studentService;

        public HomeController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> ShowStudents()
        {
            List<Student> listStudents = await _studentService.GetStudents();
            return View(listStudents);
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Access");//Page Login (as cshtml) from Access Controller
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}