using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Application.Abstractions.DataAccess;
using Web.Domain.Entities;
using Web.Infrastructure.Database.Context;

namespace Web.Infrastructure.Database
{
    public class MeterDao(DataStorageAppContext context): BaseDao<Meter>(context), IMeterDao
    {
        public async Task<List<Meter>> GetBySerialNumber(string serialNumber)
        {
            return await Context.Meters.Where(m=>m.SerialNumber.Contains(serialNumber)).ToListAsync();
        }
    }
}
