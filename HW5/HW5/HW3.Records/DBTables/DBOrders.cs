using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3.Models.DBTables
{
    public class DBOrders
    {
        public Guid Id { get; set; }

        public Guid Id_customer { get; set; }

        public Guid Id_item { get; set; }

        public int Amount { get; set; }
    }

    public class DBOrdersConfiguration : IEntityTypeConfiguration<DBOrders>
    {
        public void Configure(EntityTypeBuilder<DBOrders> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Orders");
        }
    }
}
