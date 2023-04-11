using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Asg2.DAL.Models;

namespace Asg2.BLL.Services.Contracts
{
    public interface ISubmisionsService
    {

        Task<Submision> CreateSubmission(Submision sub);

        Task<List<Submision>> GetSubmission4Students(string email);

        Task<List<Submision>> GetSubmissions();
        Task UpdateGrade(int Id, int StudentId, int LabId, string Link, string Comment, int Grade);
        Task<Submision> GetSubmissionById(int id);
    }
}
