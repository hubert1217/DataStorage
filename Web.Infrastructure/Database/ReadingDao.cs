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
    public class ReadingDao(DataStorageAppContext context) : BaseDao<Reading>(context), IReadingDao
    {
        protected override IQueryable<Reading> GetQueryable()
        {
            return Context.Readings
                .Include(r => r.Meter)
                    .ThenInclude(m => m.Type)
                .AsNoTracking();
        }

        public async Task<List<Reading>> GetByDate(DateTime date)
        {
            var startDate = new DateTime(date.Year, date.Month, 1);
            var endDate = startDate.AddMonths(1);

            //return await Context.Readings
            //    .Where(r => r.Date >= startDate && r.Date < endDate)
            //    .ToListAsync();

            return await Context.Readings
                .Where(r => r.Date == date)
                .ToListAsync();
        }
    }
}
