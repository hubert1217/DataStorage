using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Web.Application.Abstractions.DataAccess;
using Web.Application.Abstractions.Services;
using Web.Domain.Entities;

namespace Web.Application.Services
{
    public class MeterService(IMeterDao meterDao): IMeterService
    {
        public async Task<List<Meter>> GetAll()
        {
            return await meterDao.GetAll();
        }

        public async Task<Meter> GetById(int id) 
        {
            return await meterDao.GetById(id);
        }

        public async Task<Meter> GetBySerialNumber(string serialNumber) 
        {
            return await meterDao.GetBySerialNumber(serialNumber);
        }
    }
}
