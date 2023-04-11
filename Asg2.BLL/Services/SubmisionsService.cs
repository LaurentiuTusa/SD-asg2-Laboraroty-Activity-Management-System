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
    public class SubmisionsService : ISubmisionsService
    {
        private readonly IGenericRepository<Submision> _repository;

        public SubmisionsService(IGenericRepository<Submision> repository)
        {
            _repository = repository;
        }


        public async Task<Submision> CreateSubmission(Submision sub)
        {
            try
            {
                return await _repository.CreateSubmission(sub);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Submision>> GetSubmission4Students(string email)
        {
            try
            {
                return await _repository.GetSubmissions4Students(email);
            }
            catch
            {
                throw;
            }
        }

        public async Task<Submision> GetSubmissionById(int id)
        {
            return await _repository.GetSubmissionById(id);
        }

        public async Task<List<Submision>> GetSubmissions()
        {
            try
            {
                return await _repository.GetSubmissions();
            }
            catch
            {
                throw;
            }
        }

        public async Task UpdateGrade(int Id, int StudentId, int LabId, string Link, string Comment, int Grade)
        {
            var sub = await _repository.GetSubmissionById(Id);

            if (sub == null)
            {
                throw new ArgumentException("Submission not Found");
            }

            sub.Id = Id;
            sub.StudentId = StudentId;
            sub.LabId = LabId;
            sub.Link = Link;
            sub.Comment = Comment;
            sub.Grade = Grade;
            await _repository.UpdateGrade(sub);
        }
    }
}
