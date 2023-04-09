using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Asg2.DAL.Models;

namespace Asg2.BLL.Services.Contracts
{
    public interface ITeacherService
    {

        Teacher GetTeacherByEmail(string email);
        bool TeacherSignIn(string email, string password);


    }
}
