using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FCorp.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FCorp.Persistence.EntityTypeConfigurations
{
    public class OrderPositionsConfiguration : IEntityTypeConfiguration<OrderPositions>
    {
        public void Configure(EntityTypeBuilder<OrderPositions> builder)
        {
            builder.HasKey(k => k.Id);
        }
    }
}
