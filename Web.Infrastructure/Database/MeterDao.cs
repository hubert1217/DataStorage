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
    public class MeterDao(DataStorageAppContext context): BaseDao<MeterDao>(context), IMeterDao
    {
        public Task GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Meter> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Meter> GetBySerialNumber(string serialNumber)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Meter>> GetMeters() 
        { 
            return await Context.Meters.AsNoTracking().ToListAsync();
        }

        Task<List<Meter>> IMeterDao.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
