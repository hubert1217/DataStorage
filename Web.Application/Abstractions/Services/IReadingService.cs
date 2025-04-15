using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Domain.Entities;

namespace Web.Application.Abstractions.Services
{
    public interface IReadingService
    {
        Task<List<Reading>> GetAll();
        Task<Reading> GetById(int id);
    }
}
