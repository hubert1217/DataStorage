using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Domain.Entities;

namespace Web.Application.Abstractions.DataAccess
{
    public interface IUserDao
    {
        Task<List<User>> GetAll();
        Task<User> GetById(int id);
        Task<User> Insert(User user);
        Task<User> Update(int id, User user);
        Task Delete(int id);
    }
}
