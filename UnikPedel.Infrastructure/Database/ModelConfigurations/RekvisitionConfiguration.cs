using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnikPedel.Infrastructure.Database.ModelConfigurations
{
    public class RekvisitionConfiguration : IEntityTypeConfiguration<Domain.Entities.Rekvisition>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Rekvisition> entity)
        {
            entity.ToTable("Rekvisition");
            entity.HasKey(x => x.Id);
            entity.Property(a => a.Id).HasColumnName("Id");
            entity.Property(a => a.Type).HasColumnName("Type").IsRequired();
            entity.Property(a => a.Beskrivelse).HasColumnName("Beskrivelse").IsRequired();
            entity.Property(a => a.TimeCreated).HasColumnName("TimeCreated").IsRequired();
            entity.Property(a => a.Status).HasColumnName("Status").IsRequired();

            entity.HasOne(d => d.Lejer).WithMany(c => c.Rekvisitioner);
            entity.HasOne(d => d.Vicevært).WithMany(c => c.Rekvisitioner);
            entity.HasOne(a => a.Ejendom).WithMany(c => c.Rekvisitioner);
            entity.HasMany(c => c.TidRegistering).WithOne(d => d.Rekvisition);
        }
    }
}
