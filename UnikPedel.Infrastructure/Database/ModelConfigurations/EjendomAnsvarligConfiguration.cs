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

            entity.HasOne(a => a.Vicevært).WithMany(b => b.EjendomsAnsvarlig).
                HasForeignKey(i => i.ViceværtId)
                 .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(b => b.Ejendom).WithMany(d => d.EjendomsAnsvarlig).
                HasForeignKey(i => i.EjendomId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
