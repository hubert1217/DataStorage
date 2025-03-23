using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Application.Abstractions.DataAccess;
using Web.Domain.Entities;
using Web.Infrastructure.Database.Context;

namespace Web.Infrastructure.Database
{
    public class UserDao(DataStorageAppContext context) : BaseDao<UserDao>(context), IUserDao
    {
        public async Task<List<User>> GetAll()
        {
            return await Context.Users.AsNoTracking().ToListAsync();
        }

        public Task<User> Insert(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> Insert(string name, string surname, string description)
        {
            throw new NotImplementedException();
        }
    }
}
