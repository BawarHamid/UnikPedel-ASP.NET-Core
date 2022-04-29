using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnikPedel.Infrastructure.Database.ModelConfigurations
{
    public class LejlighedConfiguration : IEntityTypeConfiguration<Domain.Entities.Lejlighed>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Lejlighed> entity)
        {
            entity.ToTable("Lejlighed");
            entity.HasKey(x => x.Id);
            entity.Property(a => a.Id).HasColumnName("Id");

            entity.Property(b => b.Adresse).HasColumnName("Adresse").IsRequired();

            entity.HasOne(c => c.Afdeling).WithMany(b => b.Lejligheder);
            entity.HasMany(a => a.Bookinger).WithOne(c => c.GæsteLejlighed);
        }
    }
}
