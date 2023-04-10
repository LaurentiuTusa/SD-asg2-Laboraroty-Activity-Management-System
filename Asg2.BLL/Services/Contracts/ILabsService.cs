using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Asg2.DAL.Models;

namespace Asg2.BLL.Services.Contracts
{
    public interface ILabsService
    {
        Task<List<Lab>> GetLabs();
        Task<Lab> CreateLab(Lab l);
        Task DeleteLab(int id);
        Task<Lab> GetLabById(int id);
        Task UpdateLab(int Id, int SubjectId, int Number, DateTime Date, string Title, string Curricula, string Description, string AsgName, DateTime AsdDl, string AsgDescription);
    }
}
