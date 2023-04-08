using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Asg2.DAL.Models;
using Asg2.DAL.Repositories.Contracts;
using Asg2.BLL.Services.Contracts;

namespace Asg2.BLL.Services
{
    public class TeacherService : ITeacherService
    {

        private readonly IGenericRepository<Teacher> _repository;

        public TeacherService(IGenericRepository<Teacher> repository)
        {
            _repository = repository;
        }

        public bool TeacherSignIn(string email, string password)
        {
            var teacher = _repository.GetTeacherByEmail(email);

            if (teacher == null)
            {
                Console.WriteLine("Am returnat teacher null");
                return false;
            }

            if (Base64Encode(password) != teacher.Password)
            {
                Console.WriteLine("Pe !=: Base64Encode(password): " + Base64Encode(password) + "    teacher.Password din database: " + teacher.Password);
                return false;
            }

            Console.WriteLine("Pe ==: Base64Encode(password): " + Base64Encode(password) + "    teacher.Password din database: " + teacher.Password);
            //Console.WriteLine("Parole: ms " + Base64Encode("ms") + " |ale " + Base64Encode("ale") + " |si mihai " + Base64Encode("mihai"));
            return true;
        }

        public Teacher GetTeacherByEmail(string email)
        {
            return _repository.GetTeacherByEmail(email);
        }
        public static string Base64Encode(string s)
        {
            var sBytes = Encoding.UTF8.GetBytes(s);
            return Convert.ToBase64String(sBytes);
        }

        
    }
}
