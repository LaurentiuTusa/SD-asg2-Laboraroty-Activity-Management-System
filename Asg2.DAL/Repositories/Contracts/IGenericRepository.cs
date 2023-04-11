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
        Task<List<TModel>> GetAttendance();

        Task<List<TModel>> GetSubmissions();
        Task<List<Submision>> GetSubmissions4Students(string email);
        Task<Lab> CreateLab(Lab l);

        Task<Attendance> CreateAttendance(Attendance a);

        Task<Student> Register(Student st);

        //Task<Student> GetStudentByEmail(string email);
        Student GetStudentByEmail(string email);
        Task<Student> GetStudentById(int id);

        Task UpdateStudent(Student s);
        Teacher GetTeacherByEmail(string email);

        Token GetTokenByValue(string inputToken);

        Task<Token> AddToken(Token t);
        Task DeleteToken(string tokenData);
        Task DeleteStudent(string email);
        Task DeleteLab(int id);

        Task DeleteAttendance(int id);

        Task<Lab> GetLabById (int id);
        Task UpdateLab(Lab l);
        Task UpdateGrade(Submision s);

        Task<Submision> CreateSubmission(Submision sub);
        Task<Submision> GetSubmissionById(int id);

    }
}
