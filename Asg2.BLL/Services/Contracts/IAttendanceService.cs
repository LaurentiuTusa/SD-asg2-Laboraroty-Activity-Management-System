﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Asg2.DAL.Models;

namespace Asg2.BLL.Services.Contracts
{
    public interface IAttendanceService
    {
        Task<List<Attendance>> GetAttendance();

        Task<Attendance> CreateAttendance(Attendance a);
        Task DeleteAttendance(int id);

    }
}
