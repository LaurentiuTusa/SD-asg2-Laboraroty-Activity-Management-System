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
    public class LabsService : ILabsService
    {
        private readonly IGenericRepository<Lab> _repository;

        public LabsService(IGenericRepository<Lab> repository)
        {
            _repository = repository;
        }

        public async Task<Lab> CreateLab(Lab l)
        {
            try
            {
                return await _repository.CreateLab(l);
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteLab(int id)
        {
            await _repository.DeleteLab(id);
        }

        public async Task<Lab> GetLabById(int id)
        {
            return await _repository.GetLabById(id);
        }

        public async Task<List<Lab>> GetLabs()
        {
            try
            {
                return await _repository.GetLabs();
            }
            catch
            {
                throw;
            }
        }

        public async Task UpdateLab(int Id, int SubjectId, int Number, DateTime Date, string Title, string Curricula, string Description, string AsgName, DateTime AsdDl, string AsgDescription)
        {
            var lab = await _repository.GetLabById(Id);

            if (lab == null)
            {
                throw new ArgumentException("Lab not Found");
            }

            lab.Id = Id;
            lab.SubjectId = SubjectId;
            lab.Number = Number;
            lab.Date = Date;
            lab.Title = Title;
            lab.Curricula = Curricula;
            lab.Description = Description;
            lab.AsgName = AsgName;
            lab.AsdDl = AsdDl;
            lab.AsgDescription = AsgDescription;
            await _repository.UpdateLab(lab);
        }
    }
}
