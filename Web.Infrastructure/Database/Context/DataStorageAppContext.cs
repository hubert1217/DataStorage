using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Domain.Entities;

namespace Web.Infrastructure.Database.Context
{
    public class DataStorageAppContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<MeterType> MeterTypes { get; set; }
        public DbSet<Meter> Meters { get; set; }
        public DbSet<Reading> Readings { get; set; }

        public DataStorageAppContext(DbContextOptions<DataStorageAppContext> options) : base(options) { }
    }
}
