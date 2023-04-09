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
        public async Task<IActionResult> Login(VMLogin modelLogin)
        {

                if (modelLogin.StudentDot == true && modelLogin.TeacherDot == false)//STUDENT
                {
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

                        return RedirectToAction("Index", "Home");//TREBE SCHIMBAT IN STUDENT CONTROLLER
                    }

                    ViewData["ValidateMessage"] = "Student not found";
                    return View();
                }
               
                else if (modelLogin.StudentDot == false && modelLogin.TeacherDot == true)//TEACHER
                {
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

                        return RedirectToAction("ShowStudents", "Teacher");//TEACHER CONTROLLER
                    }

                    ViewData["ValidateMessage"] = "Teacher not found";
                    return View();
                }
                else 
                {
                    ViewData["ValidateMessage"] = "Invalid selection";
                    return View();
                }

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

        [HttpGet]
        public async Task<IActionResult> Register() // sau public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(VMRegister modelRegister)
        {
            try
            {
                Student s = new Student
                {
                    Name = modelRegister.Name,
                    Email = modelRegister.Email,
                    Password = modelRegister.Password,
                    Group = modelRegister.Group,
                    Hobby = modelRegister.Hobby
                };

                if(_tokensService.ValidateToken(modelRegister.Token))//TOKEN IS VALID
                {

                    await _studentService.Register(s);
                    await Login(new VMLogin { Email = s.Email, Password = s.Password, StudentDot = true, TeacherDot = false, KeepLoggedIn = false });
                    //delete the token
                    await _tokensService.DeleteToken(modelRegister.Token);
                    TempData["Email"] = modelRegister.Email;

                    return RedirectToAction("Privacy", "Home");//unde merge sudentul cand face login
                }

                ViewData["ValidateMessage"] = "Token invalid";
                return View();
            }
            catch
            {
                return StatusCode(StatusCodes.Status401Unauthorized, new { message = "Complete all fields" });
            }
        }

    }
}
