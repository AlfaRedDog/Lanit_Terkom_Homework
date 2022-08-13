using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace HW3.Models.DBTables
{
    public class DBItems
    {
        public Guid Id { get; set; }

        public Guid Id_provider { get; set; }

        public int Amount { get; set; }

        public int Price { get; set; }

        public DateTime Expiration_date { get; set; }
    }

    public class DBItemsConfiguration : IEntityTypeConfiguration<DBItems>
    {
        public void Configure(EntityTypeBuilder<DBItems> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Items");
        }
    }
}
