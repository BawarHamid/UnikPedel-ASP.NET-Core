using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnikPedel.Infrastructure.Database.ModelConfigurations
{
    public class BookingConfiguration : IEntityTypeConfiguration<Domain.Entities.Booking>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Booking> entity)
        {
            entity.ToTable("Booking");
            entity.HasKey(b => b.Id);
            entity.Property(b => b.Id).HasColumnName("Id");

            entity.Property(c => c.StartTid).HasColumnName("StartTid").IsRequired();
            entity.Property(b => b.SlutTid).HasColumnName("SlutTid").IsRequired();

            entity.HasOne(a => a.Lejer).WithMany(d => d.Bookings);
            
        }
    }
}
