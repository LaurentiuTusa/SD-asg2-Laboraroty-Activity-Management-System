﻿using System.Diagnostics;
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
        public async Task<ActionResult> Delete(string email)
        {
            await _studentService.DeleteStudent(email);
            return RedirectToAction("ShowStudents", "Teacher");
        }
    }
}
