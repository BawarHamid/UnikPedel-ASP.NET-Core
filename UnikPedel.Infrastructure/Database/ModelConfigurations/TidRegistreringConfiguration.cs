using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnikPedel.Domain.Entities;

namespace UnikPedel.Infrastructure.Database.ModelConfigurations
{
    class TidRegistreringConfiguration : IEntityTypeConfiguration<Domain.Entities.TidRegistering>
    {
        public void Configure(EntityTypeBuilder<TidRegistering> entity)
        {
            entity.ToTable("TidRegistrering");
            entity.HasKey(b => b.Id);
            entity.Property(b => b.Id).HasColumnName("Id");
            entity.Property(c => c.AntalTimer).HasColumnName("AntalTimer").IsRequired();
            entity.Property(b => b.RegisterDato).HasColumnName("RegisterDato").IsRequired();
            entity.HasOne(a => a.Vicevaert).WithMany(d => d.TidRegistrering).OnDelete(DeleteBehavior.ClientCascade).HasForeignKey(j => j.VicevaertId);
            entity.HasOne(a => a.Rekvisition).WithMany(d => d.TidRegistering).OnDelete(DeleteBehavior.Cascade).HasForeignKey(j => j.RekvisitionId);
        }
    }
}
