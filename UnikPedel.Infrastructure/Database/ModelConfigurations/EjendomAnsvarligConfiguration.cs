using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnikPedel.Infrastructure.Database.ModelConfigurations
{
    public class EjendomAnsvarligConfiguration : IEntityTypeConfiguration<Domain.Entities.EjendomsAnsvarlig>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.EjendomsAnsvarlig> entity)
        {
            entity.ToTable("EjendomsAnsvarlig");
            entity.HasKey(x => x.Id);
            entity.Property(b => b.Id).HasColumnName("Id");
            
            entity.HasMany(b => b.Ejendom).WithOne(d => d.EjendomsAnsvarlig).
                HasForeignKey(i => i.Id)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasMany(a => a.Vicevært).WithOne(b => b.EjendomsAnsvarlig).
                HasForeignKey(i => i.Id)
                 .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
