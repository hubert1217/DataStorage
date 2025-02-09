using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Application.Abstractions.Services;
using Web.Application.Models;

namespace Web.Application.Services
{
    public class UserService : IUserService
    {
        public async Task<List<UserModel>> GetAll() 
        {

            var user = new List<UserModel> { new UserModel { Id = 1, Name = "Tomasz", Surname = "Nasiadka", Description = "Rolnik", Email = "Tomasz@wp.pl" } };


            return user;
        }
    }
}
