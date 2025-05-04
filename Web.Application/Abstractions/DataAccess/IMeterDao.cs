using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Domain.Entities;

namespace Web.Application.Abstractions.DataAccess
{
    public interface IMeterDao
    {
        Task<List<Meter>> GetAll();
        Task<Meter> GetById(int id);
        Task<List<Meter>> GetBySerialNumber(string serialNumber);
        //Task<Meter> Insert(Meter meter);
        Task<Meter> Update(int id, Meter meter);
        Task Delete(int id);

    }
}
