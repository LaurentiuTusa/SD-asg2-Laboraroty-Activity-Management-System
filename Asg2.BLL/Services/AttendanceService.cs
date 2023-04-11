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
    public class AttendanceService : IAttendanceService
    {
        private readonly IGenericRepository<Attendance> _repository;
        public AttendanceService(IGenericRepository<Attendance> repository)
        {
            _repository = repository;
        }

        public async Task<Attendance> CreateAttendance(Attendance a)
        {
            try
            {
                return await _repository.CreateAttendance(a);
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteAttendance(int id)
        {
            await _repository.DeleteAttendance(id);
        }

        public async Task<List<Attendance>> GetAttendance()
        {
            try
            {
                return await _repository.GetAttendance();
            }
            catch
            {
                throw;
            }
        }
    }
}
