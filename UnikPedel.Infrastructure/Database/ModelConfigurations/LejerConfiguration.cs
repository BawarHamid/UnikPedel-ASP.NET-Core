using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnikPedel.Infrastructure.Database.ModelConfigurations
{
    public class LejerConfiguration : IEntityTypeConfiguration<Domain.Entities.Lejer>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Lejer> entity)
        {
            entity.ToTable("Lejer");
            entity.HasKey(b => b.LejemålId);
            entity.Property(b => b.LejemålId).HasColumnName("Id");

            entity.Property(a => a.ForNavn)
            .HasColumnName("ForNavn")
            .IsRequired();
            entity.Property(a => a.MellemNavn)
           .HasColumnName("MellemNavn")
           .IsRequired();
            entity.Property(a => a.EfterNavn)
            .HasColumnName("EfterNavn")
            .IsRequired();
            entity.Property(a => a.Email)
            .HasColumnName("Email")
            .IsRequired();
            entity.Property(a => a.Telefon)
            .HasColumnName("Telefon")
            .IsRequired();

            entity.Property(a => a.IndDato)
           .HasColumnName("IndDato")
           .IsRequired();
            entity.Property(a => a.UdDato)
           .HasColumnName("UdDato");

            entity.HasOne(c => c.Lejemål).WithMany(d => d.Lejer);
            //entity.WithMany(c => c.Lejemål).WithOne(d => d.Lejer);
            entity.HasMany(c => c.Rekvisitioner).WithOne(d => d.Lejer);
            entity.HasMany(c => c.Bookings).WithOne(d => d.Lejer);
        }
    }
}
