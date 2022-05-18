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
            entity.Property(a => a.Id).HasColumnName("Id").ValueGeneratedOnAdd();

            entity.HasOne(x => x.Vicevært)
                  .WithMany(x => x.EjendomsAnsvarlig)
                  .HasForeignKey(x => x.ViceværtId)
                .OnDelete(DeleteBehavior.NoAction);

            entity.HasOne(x => x.Ejendom)
                  .WithMany(x => x.EjendomsAnsvarlig)
                  .HasForeignKey(x => x.EjendomId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
