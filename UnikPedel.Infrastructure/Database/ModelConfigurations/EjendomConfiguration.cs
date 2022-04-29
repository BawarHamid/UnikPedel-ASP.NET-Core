﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnikPedel.Infrastructure.Database.ModelConfigurations
{
    public class EjendomConfiguration : IEntityTypeConfiguration<Domain.Entities.Ejendom>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Ejendom> entity)
        {
            entity.ToTable("Ejendom");
            entity.HasKey(x => x.Id);
            entity.Property(b => b.Id).HasColumnName("Id");

            entity.HasMany(a => a.Lejemål).WithOne(b => b.Ejendom);
            entity.HasMany(a => a.EjendomsAnsvarlig).WithOne(b => b.Ejendom);
            enity.HasMany (a => a.Rekvisition).WithOne(b => b.Ejendom);
        }
    }
}
