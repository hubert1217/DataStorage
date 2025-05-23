﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Domain.Entities;

namespace Web.Application.Abstractions.DataAccess
{
    public interface IReadingDao
    {
        Task<List<Reading>> GetAll();
        Task<Reading> GetById(int id);
        Task<List<Reading>> GetByDate(DateTime date);
    }
}
