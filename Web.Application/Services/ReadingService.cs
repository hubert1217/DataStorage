using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Application.Abstractions.DataAccess;
using Web.Application.Abstractions.Services;
using Web.Application.Models;
using Web.Domain.Entities;

namespace Web.Application.Services
{
    public class ReadingService(IReadingDao readingDao) : IReadingService
    {
        public async Task<List<ReadingModel>> GetAll()
        {
            List<Reading> readings = await readingDao.GetAll();
            return ReadingModel.ToList(readings);
        }

        public async Task<ReadingModel> GetById(int id) 
        {
            Reading reading = await readingDao.GetById(id);
            return ReadingModel.From(reading);
        }

        public async Task<List<ReadingModel>> GetByDate(DateTime date) 
        {
            List<Reading> readings = await readingDao.GetByDate(date);
            return ReadingModel.ToList(readings);
        }
    }
}
