using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Asg2.DAL.Models;

namespace Asg2.BLL.Services.Contracts
{
    public interface IStudentService
    {
        Task<List<Student>> GetStudents();
        //Task<Student> GetStudentByEmail(string email);
        Student GetStudentByEmail(string email);

        Task DeleteStudent(string email);
        Task<Student> Register(Student st);
        bool StudentSignIn(string email, string password);
    }
}
