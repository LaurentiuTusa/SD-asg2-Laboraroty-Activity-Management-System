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

        /*        public Student GetStudentByEmail(string email)
                {
                    var student = _sdAsg2Context.Students.FirstOrDefault(s => s.Email == email);

                    if (student == null)
                    {
                        return null;
                    }

                    return new Student
                    {
                        Id = student.Id,
                        Name = student.Name,
                        Email = student.Email,
                        Password = student.Password,
                        Group = student.Group,
                        Hobby = student.Hobby
                    };
                }*/

        /*        public async Task<TModel> GetStudentByEmail(string email)
                {
                    try
                    {
                        return await _sdAsg2Context.Set<TModel>()
                                                   .FirstOrDefaultAsync(s => s.Email == email);
                    }
                    catch
                    {
                        throw;
                    }
                }*/

        public Student GetStudentByEmail(string email)
        {
            return _sdAsg2Context.Students.FirstOrDefault(s => s.Email == email);
        }

    }
}
