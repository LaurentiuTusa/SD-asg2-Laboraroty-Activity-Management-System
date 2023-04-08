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
    }
}
