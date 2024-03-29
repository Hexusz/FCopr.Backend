﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FCorp.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FCorp.Persistence.EntityTypeConfigurations
{
    public class GoodConfiguration : IEntityTypeConfiguration<Good>
    {
        public void Configure(EntityTypeBuilder<Good> builder)
        {
            builder.Property(e => e.Articul).ValueGeneratedOnAdd();
            builder.HasKey(good => good.Articul);
            builder.HasIndex(good => good.Articul).IsUnique();
        }
    }
}
