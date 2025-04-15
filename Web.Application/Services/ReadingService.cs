using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Application.Abstractions.DataAccess;
using Web.Application.Abstractions.Services;
using Web.Domain.Entities;

namespace Web.Application.Services
{
    public class ReadingService(IReadingDao readingDao) : IReadingService
    {
        public async Task<List<Reading>> GetAll()
        {
            return await readingDao.GetAll();
        }

        public async Task<Reading> GetById(int id) 
        {
            return await readingDao.GetById(id);
        }

        public async Task<List<Reading>> GetByDate(DateTime date) 
        {
            return await readingDao.GetByDate(date);
        }
    }
}
