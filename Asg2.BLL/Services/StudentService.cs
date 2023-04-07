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


    }
}
