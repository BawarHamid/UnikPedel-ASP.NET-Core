using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnikPedel.Infrastructure.Database.ModelConfigurations
{
    public class LejemaalConfiguration : IEntityTypeConfiguration<Domain.Entities.Lejemaal>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Lejemaal> entity)
        {
            entity.ToTable("Lejemål");
            entity.HasKey(b => b.Id);
            entity.Property(b => b.Id).HasColumnName("Id");

            entity.Property(a => a.EjendomId)
            .HasColumnName("EjendomId");
            entity.Property(a => a.VejNavn)
            .HasColumnName("VejNavn")
            .IsRequired();
            entity.Property(a => a.BygningsNummer)
           .HasColumnName("BygningsNummer")
           .IsRequired();
            entity.Property(a => a.AndenAdresse)
           .HasColumnName("AndenAdresse")
           .IsRequired();
            entity.Property(a => a.PostNummer)
           .HasColumnName("PostNummer")
           .IsRequired();
            entity.Property(a => a.City)
           .HasColumnName("City")
           .IsRequired();
            entity.Property(a => a.Region)
           .HasColumnName("Region")
           .IsRequired();
            entity.Property(a => a.LandKode)
           .HasColumnName("LandKode")
           .IsRequired();

            entity.HasOne(x => x.Ejendom)
                .WithMany(x => x.Lejemaal)
                .HasForeignKey(x => x.EjendomId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
