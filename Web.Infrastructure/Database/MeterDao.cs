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
    public class MeterDao(DataStorageAppContext context): BaseDao<MeterDao>(context), IMeterDao
    {
        public async Task<List<Meter>> GetAll()
        {
            return await Context.Meters.ToListAsync();
        }

        public async Task<Meter> GetById(int id)
        {
            return await Context.Meters.Where(m => m.Id == id).FirstAsync();
        }

        public async Task<List<Meter>> GetBySerialNumber(string serialNumber)
        {
            return await Context.Meters.Where(m=>m.SerialNumber.Contains(serialNumber)).ToListAsync();
        }

        public async Task<Meter> Insert(Meter meter)
        {
            var entry = await Context.Meters.AddAsync(meter);
            await Context.SaveChangesAsync();
            return entry.Entity;
        }

        public async Task<Meter> Update(int id, Meter meter)
        {
            var update = await GetById(id);

            update.SerialNumber = meter.SerialNumber;
            update.Address = meter.Address;
            Context.Meters.Update(update);
            await Context.SaveChangesAsync();
            return update;
        }

        public async Task Delete(int id)
        {
            var delete = await GetById(id);
            Context.Meters.Remove(delete);
            await Context.SaveChangesAsync();
        }
    }
}
