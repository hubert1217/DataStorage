using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Application.Models;

namespace Web.Application.Abstractions.Services
{
    public interface IUserService
    {
        Task<List<UserModel>> GetAll();
    }
}
