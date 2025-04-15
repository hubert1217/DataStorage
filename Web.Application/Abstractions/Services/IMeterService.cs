using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Domain.Entities;

namespace Web.Application.Abstractions.Services
{
    public interface IMeterService
    {
        Task<List<Meter>> GetAll();
        Task<Meter> GetById(int id);
        Task<Meter> GetBySerialNumber(string serialNumber);
    }
}
