using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnikPedel.Infrastructure.Database.ModelConfigurations
{
    public class LejemålConfiguration : IEntityTypeConfiguration<Domain.Entities.Lejemål>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Lejemål> entity)
        {
            entity.ToTable("Lejemål");
            entity.HasKey(b => b.Id);
            entity.Property(b => b.Id).HasColumnName("Id");

            entity.Property(a => a.VejNavn)
            .HasColumnName("VejNavn")
            .IsRequired();

            entity.HasOne(e => e.Ejendom).WithMany(a => a.Lejemål);
            entity.HasOne(c => c.Lejer).WithOne(d => d.Lejemål);
        }
    }
}
