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
        Task<UserModel> GetById(int id);
        Task<UserModel> Update(int id, string firstName, string lastName, string description, string email);
        Task<UserModel> Create(string firstName, string lastName, string description, string email);
        Task Delete(int id);


    }
}
