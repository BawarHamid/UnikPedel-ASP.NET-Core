using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnikPedel.Infrastructure.Database.ModelConfigurations
{
    public class AfdelingAnsvarligConfiguration : IEntityTypeConfiguration<Domain.Entities.EjendomsAnsvarlig>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.EjendomsAnsvarlig> entity)
        {
            entity.ToTable("AfdelingAnsvarlig");
            entity.HasKey(x => x.Id);
            entity.Property(b => b.Id).HasColumnName("Id");

            entity.HasOne(a => a.Vicevært).WithMany(b => b.AfdelingAnsvarlig).
                HasForeignKey(i => i.ViceværtId)
                 .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(b => b.Afdeling).WithMany(d => d.AfdelingAnsvarlig).
                HasForeignKey(i => i.AfdelingId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
