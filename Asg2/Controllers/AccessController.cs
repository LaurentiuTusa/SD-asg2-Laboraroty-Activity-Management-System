using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Asg2.Models;
using Asg2.BLL.Services.Contracts;
using Asg2.DAL.Models;

namespace Asg2.Controllers
{
    public class AccessController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly ITeacherService _teacherService;
        private readonly ITokensService _tokensService;

        public AccessController(IStudentService studentService, ITeacherService teacherService, ITokensService tokensService)
        {
            _studentService = studentService;
            _teacherService = teacherService;
            _tokensService = tokensService;
        }

         public IActionResult Login()
         {
             ClaimsPrincipal claimUser = HttpContext.User;

             if (claimUser.Identity.IsAuthenticated)
                 return RedirectToAction("Privacy", "Home");

             return View();
         }

     [HttpPost]
     public async Task<IActionResult> Login(VMLogin modelLogin, string student, string teacher)
     {
        //if (ModelState.IsValid)
        //{
            //if (!string.IsNullOrEmpty(student))// User clicked 'Login Student' button
            if (modelLogin.StudentDot == true && modelLogin.TeacherDot == false)
            {

                //await LoginStudent(modelLogin);
                if (_studentService.StudentSignIn(modelLogin.Email, modelLogin.Password))
                {
                    List<Claim> claims = new List<Claim>(){
                         new Claim(ClaimTypes.NameIdentifier, modelLogin.Email),
                         new Claim("OtherProperties", "Example Role")
                     };

                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    AuthenticationProperties properties = new AuthenticationProperties()
                    {
                        AllowRefresh = true,
                        IsPersistent = modelLogin.KeepLoggedIn
                    };

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity), properties);

                    TempData["Email"] = modelLogin.Email;

                    return RedirectToAction("Index", "Home");
                }

                ViewData["ValidateMessage"] = "Student not found";
                return View();
            }
            //else if (!string.IsNullOrEmpty(teacher))// User clicked 'Login Teacher' button
            else if (modelLogin.StudentDot == false && modelLogin.TeacherDot == true)
            {
                Console.WriteLine("Am inregistrat ca s-a apasat Login Teacher");
                //await LoginTeacher(modelLogin);
                if (_teacherService.TeacherSignIn(modelLogin.Email, modelLogin.Password))
                {
                    List<Claim> claims = new List<Claim>(){
                         new Claim(ClaimTypes.NameIdentifier, modelLogin.Email),
                         new Claim("OtherProperties", "Example Role")
                     };

                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    AuthenticationProperties properties = new AuthenticationProperties()
                    {
                        AllowRefresh = true,
                        //IsPersistent = modelLogin.KeepLoggedIn
                    };

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity), properties);

                    TempData["Email"] = modelLogin.Email;//This is how you pass data to subsequent controllers and views

                    return RedirectToAction("ShowStudents", "Home");
                }

                ViewData["ValidateMessage"] = "Teacher not found";
                return View();
            }
            else 
            {
                ViewData["ValidateMessage"] = "Invalid selection";
                return View();
            }
        //}//de la if (ModelState.IsValid)

            // Validation failed, show error message
            ViewData["ValidateMessage"] = "Invalid email or password.";
            return View();
     }

    /* public IActionResult LoginStudent()
     {
         ClaimsPrincipal claimUser = HttpContext.User;

         if (claimUser.Identity.IsAuthenticated)
             return RedirectToAction("Index", "Home");

         return View();
     }
     [HttpPost]
     public async Task<IActionResult> LoginStudent(VMLogin modelLogin)
     {//if email and password match in the database
         if (_studentService.StudentSignIn(modelLogin.Email, modelLogin.Password))
         {
             List<Claim> claims = new List<Claim>(){
                 new Claim(ClaimTypes.NameIdentifier, modelLogin.Email),
                 new Claim("OtherProperties", "Example Role")
             };

             ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

             AuthenticationProperties properties = new AuthenticationProperties()
             {
                 AllowRefresh = true,
                 IsPersistent = modelLogin.KeepLoggedIn
             };

             await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                 new ClaimsPrincipal(claimsIdentity), properties);

             TempData["Email"] = modelLogin.Email;

             return RedirectToAction("Index", "Home");
         }

         ViewData["ValidateMessage"] = "User not found";
         return View();
     }


     public IActionResult LoginTeacher()
     {
         ClaimsPrincipal claimUser = HttpContext.User;

         if (claimUser.Identity.IsAuthenticated)
             return RedirectToAction("ShowStudents", "Home");

         return View();
     }
     [HttpPost]
     public async Task<IActionResult> LoginTeacher(VMLogin modelLogin)
     {//if email and password match in the database
         if (_teacherService.TeacherSignIn(modelLogin.Email, modelLogin.Password))
         {
             List<Claim> claims = new List<Claim>(){
                 new Claim(ClaimTypes.NameIdentifier, modelLogin.Email),
                 new Claim("OtherProperties", "Example Role")
             };

             ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

             AuthenticationProperties properties = new AuthenticationProperties()
             {
                 AllowRefresh = true,
                 //IsPersistent = modelLogin.KeepLoggedIn
             };

             await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                 new ClaimsPrincipal(claimsIdentity), properties);

             TempData["Email"] = modelLogin.Email;//This is how you pass data to subsequent controllers and views

             return RedirectToAction("ShowStudents", "Home");
         }

         ViewData["ValidateMessage"] = "User not found";
         return View();
     }*/


    }
}
