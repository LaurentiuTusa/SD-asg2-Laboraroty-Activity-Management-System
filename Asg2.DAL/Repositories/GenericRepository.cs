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

        public async Task<List<TModel>> GetAttendance()
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

        public async Task<Lab> CreateLab(Lab l)
        {
            await _sdAsg2Context.Labs.AddAsync(l);
            await _sdAsg2Context.SaveChangesAsync();
            return l;
        }

        public async Task DeleteLab(int id)
        {
            var lab = await _sdAsg2Context.Labs.FindAsync(id);

            if (lab == null)
            {
                throw new ArgumentException($"Performance with specified id doe not exist");
            }

            _sdAsg2Context.Labs.Remove(lab);
            await _sdAsg2Context.SaveChangesAsync();
        }

        public async Task<Lab> GetLabById(int id)
        {
            return await _sdAsg2Context.Labs.FindAsync(id);
        }

        public async Task<Student> GetStudentById(int id)
        {
            return await _sdAsg2Context.Students.FindAsync(id);
        }

        public async Task UpdateStudent(Student s)
        {
            _sdAsg2Context.Students.Update(s);
            await _sdAsg2Context.SaveChangesAsync();
        }

        public async Task UpdateLab(Lab l)
        {
            _sdAsg2Context.Labs.Update(l);
            await _sdAsg2Context.SaveChangesAsync();
        }


    }
}
