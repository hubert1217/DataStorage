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
    public class UserDao(DataStorageAppContext context) : BaseDao<User>(context), IUserDao
    {
        public override async Task<User> Insert(User user)
        {
            var entity = await base.Insert(user);
            return entity;
        }
    }
}
