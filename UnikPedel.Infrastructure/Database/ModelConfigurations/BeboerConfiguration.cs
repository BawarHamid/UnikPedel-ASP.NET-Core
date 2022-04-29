using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnikPedel.Infrastructure.Database.ModelConfigurations
{
    public class BeboerConfiguration : IEntityTypeConfiguration<Domain.Entities.Lejer>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Lejer> entity)
        {
            entity.ToTable("Beboer");
            entity.HasKey(b => b.Id);
            entity.Property(b => b.Id).HasColumnName("Id");

            entity.Property(a => a.Navn)
            .HasColumnName("Navn")
            .IsRequired();
            entity.Property(a => a.EfterNavn)
            .HasColumnName("EfterNavn")
            .IsRequired();

            entity.Property(a => a.Adresse)
            .HasColumnName("Adresse")
            .IsRequired();

            entity.Property(a => a.Email)
            .HasColumnName("Email")
            .IsRequired();

            entity.Property(a => a.Telefon)
            .HasColumnName("Telefon")
            .IsRequired();

            entity.HasMany(c => c.Rekvisitioner).WithOne(d => d.Beboer);
            entity.HasMany(c => c.Bookinger).WithOne(d => d.Beboer);
            entity.HasOne(c => c.Afdeling).WithMany(d => d.Beboer);
        }
    }
}
