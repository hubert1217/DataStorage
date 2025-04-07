using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Application.Abstractions.DataAccess;
using Web.Application.Abstractions.Services;
using Web.Application.Extensions;
using Web.Application.Models;
using Web.Domain.Entities;

namespace Web.Application.Services
{
    public class UserService(IUserDao userDao) : IUserService
    {
      
        public async Task<List<UserModel>> GetAll() 
        {
            List<User> userList = await userDao.GetAll();
            return UserModel.ToList(userList);
        }

        //public async Task<UserModel> Create(string name, string surname, string description)
        //{
        //    await ValidateUser(name, surname, description);

        //    User user = await userDao.Insert(name, surname, description);

        //    return UserModel.From(user);

        //}

        private async Task ValidateUser(string name, string surname, string description)
        {
            if (name.IsNullOrWhiteSpace()) 
            { 
                throw new ArgumentNullException(nameof(name), "Name cannot be null or empty");
            }


        }

        public async Task<UserModel> Update(int id, string firstName, string lastName, string description, string email)
        {
            return new UserModel();
        }

        public async Task<UserModel> Create(string firstName, string lastName, string description, string email)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
