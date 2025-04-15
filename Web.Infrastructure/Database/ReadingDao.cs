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
    public class ReadingDao(DataStorageAppContext context) : BaseDao<ReadingDao>(context), IReadingDao
    {
        public async Task<List<Reading>> GetAll()
        {
            return await Context.Readings.Include(r=>r.Meter).ThenInclude(m=>m.Type).ToListAsync();
        }

        public async Task<Reading> GetById(int id)
        {
            return await Context.Readings.Where(r=>r.Id==id).FirstAsync();
        }

        public async Task<List<Reading>> GetByDate(DateTime date)
        {
            var startDate = new DateTime(date.Year, date.Month, 1);
            var endDate = startDate.AddMonths(1);

            return await Context.Readings
                .Where(r => r.Date >= startDate && r.Date < endDate)
                .ToListAsync();
        }


    }
}
