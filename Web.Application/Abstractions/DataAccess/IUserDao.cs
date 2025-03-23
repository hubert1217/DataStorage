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

        Task<User> Insert(string name, string surname, string description);
    }
}
