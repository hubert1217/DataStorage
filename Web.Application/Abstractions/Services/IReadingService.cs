using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Application.Models;
using Web.Domain.Entities;

namespace Web.Application.Abstractions.Services
{
    public interface IReadingService
    {
        Task<List<ReadingModel>> GetAll();
        Task<ReadingModel> GetById(int id);
        Task<List<ReadingModel>> GetByDate(DateTime date);
    }
}
