using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Asg2.DAL.Models;

namespace Asg2.DAL.Repositories.Contracts
{
    public interface IGenericRepository<TModel> where TModel : class
    {


        Task<List<TModel>> GetStudents();

        Task<List<TModel>> GetLabs();

        Task<Student> Register(Student st);

        //Task<Student> GetStudentByEmail(string email);
        Student GetStudentByEmail(string email);
        Teacher GetTeacherByEmail(string email);

        Token GetTokenByValue(string inputToken);

        Task<Token> AddToken(Token t);
        Task DeleteToken(string tokenData);
        Task DeleteStudent(string email);
    }
}
