using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Asg2.DAL.DataContext;
using Asg2.DAL.Models;
using Asg2.DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Asg2.DAL.Repositories
{
    public class GenericRepository<TModel> : IGenericRepository<TModel> where TModel : class
    {

        private readonly SdAsg2Context _sdAsg2Context;

        public GenericRepository(SdAsg2Context sdAsg2Context)
        {
            _sdAsg2Context = sdAsg2Context;
        }


        //METHODS IMPLEMENTATIONS
        public async Task<List<TModel>> GetStudents()
        {
            try
            {
                return await _sdAsg2Context.Set<TModel>().ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public Student GetStudentByEmail(string email)
        {
            return _sdAsg2Context.Students.FirstOrDefault(s => s.Email == email);
        }

        public Teacher GetTeacherByEmail(string email)
        {
            return _sdAsg2Context.Teachers.FirstOrDefault(s => s.Email == email);
        }

        public async Task<Student> Register(Student st)
        {
            await _sdAsg2Context.Students.AddAsync(st);
            await _sdAsg2Context.SaveChangesAsync();
            return st;
        }

        public async Task<Token> AddToken(Token t)
        {
            await _sdAsg2Context.Tokens.AddAsync(t);
            await _sdAsg2Context.SaveChangesAsync();
            return t;
        }

        public Token GetTokenByValue(string inputToken)
        {
            return _sdAsg2Context.Tokens.FirstOrDefault(t => t.Token1 == inputToken);
        }

        public async Task DeleteToken(string tokenData)
        {
            var token = GetTokenByValue(tokenData);

            if(token == null)
            {
                throw new ArgumentException($"Performance with specified string doe not exist");
            }

            _sdAsg2Context.Tokens.Remove(token);
            await _sdAsg2Context.SaveChangesAsync();
        }

        public async Task<List<TModel>> GetLabs()
        {
            try
            {
                return await _sdAsg2Context.Set<TModel>().ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteStudent(string email)
        {
            var stud = GetStudentByEmail(email);

            if(stud == null)
            {
                throw new ArgumentException($"Performance with specified string doe not exist");
            }

            _sdAsg2Context.Students.Remove(stud);
            await _sdAsg2Context.SaveChangesAsync();
        }
    }
}
