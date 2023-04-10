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
    public class StudentService : IStudentService
    {

        private readonly IGenericRepository<Student> _repository;

        public StudentService(IGenericRepository<Student> repository)
        {
            _repository = repository;
        }

        //METHOD CALLS
        public async Task<List<Student>> GetStudents()
        {
            try
            {
                return await _repository.GetStudents();
            }
            catch
            {
                throw;
            }
        }

        public Student GetStudentByEmail(string email)
        {
            return _repository.GetStudentByEmail(email);
        }

        public bool StudentSignIn(string email, string password)
        {
            var student = _repository.GetStudentByEmail(email);

            if (student == null)
            {
                Console.WriteLine("Am returnat student null");
                return false;
            }

            if (Base64Encode(password) != student.Password)
            {
                Console.WriteLine("Pe !=: Base64Encode(password): " + Base64Encode(password) + "    teacher.Password din database: " + student.Password);
                return false;
            }

            Console.WriteLine("Pe ==: Base64Encode(password): " + Base64Encode(password) + "    teacher.Password din database: " + student.Password);
            return true;
        }


        public static string Base64Encode(string s)
        {
            var sBytes = Encoding.UTF8.GetBytes(s);
            return Convert.ToBase64String(sBytes);
        }

        public async Task<Student> Register(Student st)
        {
            try
            {
                st.Password = Base64Encode(st.Password);
                return await _repository.Register(st);
            } 
            catch
            {
                throw;
            }
            
        }

        public async Task DeleteStudent(string email)
        {
            await _repository.DeleteStudent(email);
        }

        public async Task<Student> GetStudentById(int id)
        {
            return await _repository.GetStudentById(id);
        }

        public async Task UpdateStudent(int Id, string Name, string Email, string Password, string Group, string Hobby)
        {
            var student = await _repository.GetStudentById(Id);

            if(student == null)
            {
                throw new ArgumentException("Student not Found");
            }

            student.Id = Id;
            student.Name = Name;
            student.Email = Email;
            student.Password = Password;
            student.Group = Group;
            student.Hobby = Hobby;
            await _repository.UpdateStudent(student);
        }
    }
}
