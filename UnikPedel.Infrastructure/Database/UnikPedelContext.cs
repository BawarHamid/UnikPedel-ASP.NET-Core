using Microsoft.EntityFrameworkCore;
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

        public DbSet<Domain.Entities.Lejemål> afdelinger { get; set; }
        public DbSet<Domain.Entities.EjendomsAnsvarlig> afdelingAnsvarlig { get; set; }
        public DbSet<Domain.Entities.Lejer> beboer { get; set; }
        public DbSet<Domain.Entities.Booking> booking { get; set; }
        public DbSet<Domain.Entities.Ejendom> ejendom { get; set; }
        public DbSet<Domain.Entities.Lejlighed> lejlighed { get; set; }
        public DbSet<Domain.Entities.Rekvisition> rekvisition { get; set; }
        public DbSet<Domain.Entities.Vicevært> vicevært { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //this will apply configs from separate classes
            //which implemented IEntityTypeConfiguration<T>

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
