using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnikPedel.Infrastructure.Database.ModelConfigurations
{
    public class ViceværtConfiguration : IEntityTypeConfiguration<Domain.Entities.Vicevært>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Vicevært> entity)
        {
            entity.ToTable("Vicevært");
            entity.HasKey(x => x.Id);
            entity.Property(a => a.Id).HasColumnName("Id");

            entity.Property(a => a.Navn).HasColumnName("Navn").IsRequired();
            entity.Property(a => a.EfterNavn).HasColumnName("efterNavn").IsRequired();
            entity.Property(a => a.Email).HasColumnName("Email").IsRequired();

            entity.HasMany(c => c.EjendomsAnsvarlig).WithOne(d => d.Vicevært);
            entity.HasMany(c => c.Rekvisitioner).WithOne(d => d.Vicevært);
        }
    }
}
