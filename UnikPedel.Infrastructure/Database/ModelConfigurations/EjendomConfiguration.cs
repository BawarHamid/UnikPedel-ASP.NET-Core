using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnikPedel.Infrastructure.Database.ModelConfigurations
{
    public class EjendomConfiguration : IEntityTypeConfiguration<Domain.Entities.Ejendom>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Ejendom> entity)
        {
            entity.ToTable("Ejendom");
            entity.HasKey(x => x.Id);
            entity.Property(b => b.Id).HasColumnName("Id");
            entity.Property(a => a.VejNavn)
            .HasColumnName("VejNavn")
            .IsRequired();
            entity.Property(a => a.BygningsNummer)
           .HasColumnName("BygningsNummer")
           .IsRequired();
            entity.Property(a => a.PostNummer)
           .HasColumnName("PostNummer")
           .IsRequired();
            entity.Property(a => a.By)
           .HasColumnName("City")
           .IsRequired();
            entity.Property(a => a.Region)
           .HasColumnName("Region")
           .IsRequired();
            entity.Property(a => a.LandKode)
           .HasColumnName("LandKode")
           .IsRequired();
        }
    }
}
