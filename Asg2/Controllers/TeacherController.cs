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
    public class TeacherController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly ITeacherService _teacherService;
        private readonly ITokensService _tokensService;
        private readonly IAttendanceService _attendanceService;
        private readonly ILabsService _labsService;
        private readonly ISubjectsService _subjectsService;
        private readonly ISubmisionsService _submisionsService;

        public TeacherController(IStudentService studentService, ITeacherService teacherService, ITokensService tokensService, IAttendanceService attendanceService, ILabsService labsService, ISubjectsService subjectsService, ISubmisionsService submisionsService)
        {
            _studentService = studentService;
            _teacherService = teacherService;
            _tokensService = tokensService;
            _attendanceService = attendanceService;
            _labsService = labsService;
            _subjectsService = subjectsService;
            _submisionsService = submisionsService;
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Access");//Page "Login" (as cshtml) from "Access" Controller
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> ShowStudents()
        {
            List<Student> listStudents = await _studentService.GetStudents();
            return View(listStudents);
        }


        public async Task<IActionResult> ShowLabs()
        {
            List<Lab> listLab = await _labsService.GetLabs();
            return View(listLab);
        }

        //[HttpPost] nu merge. Poate cu IActionResult
        public async Task<ActionResult> GenerateToken()
        {
            await _tokensService.AddToken();
            return RedirectToAction("ShowLabs", "Teacher");
        }
        public async Task<ActionResult> DeleteS(string email)
        {
            await _studentService.DeleteStudent(email);
            return RedirectToAction("ShowStudents", "Teacher");
        }

        [HttpGet]
        public async Task<ActionResult> EditS(int Id)
        {
            var student = await _studentService.GetStudentById(Id);
            if(student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost]
        public async Task<ActionResult> EditS(VMUpdateStudent modelStudent, int Id/*, string Name, string Email, string Password, string Group, string Hobby*/)
        {
            try
            {                                   //Id e salvat cand se da click pe Edit
                await _studentService.UpdateStudent(Id, modelStudent.Name, modelStudent.Email, modelStudent.Password, modelStudent.Group, modelStudent.Hobby);
                return RedirectToAction("ShowStudents", "Teacher");
            }
            catch
            {
                return StatusCode(StatusCodes.Status401Unauthorized, new { message = "Complete all fields" });
            }
        }

        public async Task<ActionResult> DeleteL(int id)
        {
            await _labsService.DeleteLab(id);
            return RedirectToAction("ShowLabs", "Teacher");
        }

        [HttpGet]
        public async Task<ActionResult> CreateLab()
        {
            Console.WriteLine("CreateLab mic");
            return View();
        }

        //[HttpPost]
        public async Task<ActionResult> CreateLab(VMCreateLab modelLab/*int id, int subject_id, int number, DateTime date, string title, string curricula, string description, string asg_name, DateTime asg_dl, string asg_description*/)
        {
            try
            {
                Console.WriteLine("CreateLab MARE");
                Lab l = new Lab
                {
                    //Id = id,
                    SubjectId = modelLab.SubjectId,
                    Number = modelLab.Number,
                    Date = modelLab.Date,
                    Title = modelLab.Title,
                    Curricula = modelLab.Curricula,
                    Description = modelLab.Description,
                    AsgName = modelLab.AsgName,
                    AsdDl = modelLab.AsgDl,
                    AsgDescription = modelLab.AsgDescription
                };

                Console.WriteLine("**********Subject_id: " + modelLab.SubjectId);
                await _labsService.CreateLab(l);
                return RedirectToAction("ShowLabs", "Teacher");
            }
            catch
            {
                return RedirectToAction("CreateLab", "Teacher");
            }/////////////////////////////////////eroare la Create Lab foreign key cu subject id
        }

        [HttpGet]
        public async Task<ActionResult> EditL(int Id)
        {
            var lab = await _labsService.GetLabById(Id);
            if (lab == null)
            {
                return NotFound();
            }
            return View(lab);
        }

        [HttpPost]                          
        public async Task<ActionResult> EditL(VMUpdateLab modelLab, int Id)
        {
            try
            {                              //Id e salvat cand se da click pe Edit
                await _labsService.UpdateLab(Id, modelLab.SubjectId, modelLab.Number, modelLab.Date, modelLab.Title, modelLab.Curricula, modelLab.Description, modelLab.AsgName, modelLab.AsgDl, modelLab.AsgDescription);
                return RedirectToAction("ShowLabs", "Teacher");
            }
            catch
            {
                return StatusCode(StatusCodes.Status401Unauthorized, new { message = "Complete all fields" });
            }
        }

        public async Task<IActionResult> ShowAttendance()
        {
            List<Attendance> attendances = await _attendanceService.GetAttendance();
            return View(attendances);
        }

        [HttpGet]
        public async Task<ActionResult> CreateAttendance()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateAttendance(VMCreateAttendance modelAttendance)
        {
            try
            {
                Attendance att = new Attendance
                {
                    //Id = id,
                    LabId = modelAttendance.LabId,
                    StudentId = modelAttendance.StudentId
    
                };

                await _attendanceService.CreateAttendance(att);
                return RedirectToAction("ShowAttendance", "Teacher");
            }
            catch
            {
                return RedirectToAction("CreateAttendance", "Teacher");
            }
        }

        public async Task<ActionResult> DeleteA(int id)
        {
            await _attendanceService.DeleteAttendance(id);
            return RedirectToAction("ShowAttendance", "Teacher");
        }

        public async Task<IActionResult> ShowSubmissions()
        {
            List<Submision> subs = await _submisionsService.GetSubmissions();
            return View(subs);
        }

        [HttpGet]
        public async Task<ActionResult> Grade(int Id)
        {
            var sub = await _submisionsService.GetSubmissionById(Id);
            if (sub == null)
            {
                return NotFound();
            }
            return View(sub);
        }

        [HttpPost]                                                                                              //doar pt grade field
        public async Task<ActionResult> Grade(int Id, int StudentId, int LabId, string Link, string Comment, VMGrade modelGrade)
        {
            try
            {                                   
                await _submisionsService.UpdateGrade(Id, StudentId, LabId, Link, Comment, modelGrade.Grade);
                return RedirectToAction("ShowSubmissions", "Teacher");
            }
            catch
            {
                return StatusCode(StatusCodes.Status401Unauthorized, new { message = "Complete all fields" });
            }
        }
    }
}
