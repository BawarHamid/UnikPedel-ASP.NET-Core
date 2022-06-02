﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UnikPedel.Infrastructure.Database
{
    public class UnikPedelContext : DbContext
    {
        public UnikPedelContext(DbContextOptions<UnikPedelContext> options)
            : base(options)
        {
        }

        public DbSet<Domain.Entities.Lejemaal> Lejemaal { get; set; }
        public DbSet<Domain.Entities.EjendomsAnsvarlig> EjendomsAnsvarlig { get; set; }
        public DbSet<Domain.Entities.Lejer> Lejer { get; set; }
        public DbSet<Domain.Entities.Booking> Booking { get; set; }
        public DbSet<Domain.Entities.Ejendom> Ejendom { get; set; }
       
        public DbSet<Domain.Entities.Rekvisition> Rekvisition { get; set; }
        public DbSet<Domain.Entities.Vicevaert> Vicevaert { get; set; }
        public DbSet<Domain.Entities.TidRegistering> TidRegistrering { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //this will apply configs from separate classes
            //which implemented IEntityTypeConfiguration<T>

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
