using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnikPedel.Infrastructure.Database.ModelConfigurations
{
    public class AfdelingConfiguration : IEntityTypeConfiguration<Domain.Entities.Lejemål>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Lejemål> entity)
        {
            entity.ToTable("Afdeling");
            entity.HasKey(b => b.Id);
            entity.Property(b => b.Id).HasColumnName("Id");

            entity.Property(a => a.Navn)
            .HasColumnName("Navn")
            .IsRequired();

            entity.HasOne(e => e.Ejendom).WithMany(a => a.Afdelinger);
            entity.HasMany(a => a.AfdelingAnsvarlig).WithOne(b => b.Afdeling);
            entity.HasMany(c => c.Beboer).WithOne(d => d.Afdeling);
        }
    }
}
