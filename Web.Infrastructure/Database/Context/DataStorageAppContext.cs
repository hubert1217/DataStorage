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
        public DbSet<Address> Address { get; set; }
        public DbSet<MeterType> MeterTypes { get; set; }
        public DbSet<Meter> Meters { get; set; }
        public DbSet<Reading> Readings { get; set; }

        public DataStorageAppContext(DbContextOptions<DataStorageAppContext> options) : base(options) { }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    // Reading → Meter
        //    modelBuilder.Entity<Reading>()
        //        .HasOne(r => r.Meter)
        //        .WithMany() // jeśli dodasz kolekcję w Meterze, np. public ICollection<Reading> Readings, to zmień na WithMany(m => m.Readings)
        //        .HasForeignKey(r => r.MeterId)
        //        .OnDelete(DeleteBehavior.Cascade);

        //    // Meter → Address
        //    modelBuilder.Entity<Meter>()
        //        .HasOne(m => m.Address)
        //        .WithMany() // analogicznie jak wyżej: WithMany(a => a.Meters) jeśli chcesz kolekcję w Address
        //        .HasForeignKey(m => m.AddressId)
        //        .OnDelete(DeleteBehavior.Restrict);

        //    // Meter → MeterType
        //    modelBuilder.Entity<Meter>()
        //        .HasOne(m => m.Type)
        //        .WithMany() // WithMany(t => t.Meters) jeżeli chcesz kolekcję w MeterType
        //        .HasForeignKey(m => m.TypeId)
        //        .OnDelete(DeleteBehavior.Restrict);

        //    // Dodatkowo możesz dodać np. unikalność numeru seryjnego w Meter
        //    modelBuilder.Entity<Meter>()
        //        .HasIndex(m => m.SerialNumber)
        //        .IsUnique();
        //}


    }
}
