using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace HW3.Models.DBTables
{
    public class DBCustomers
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Surename { get; set; }

        public string Adress { get; set; }
    }

    public class DBCustomersConfiguration : IEntityTypeConfiguration<DBCustomers>
    {
        public void Configure(EntityTypeBuilder<DBCustomers> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Customers");
        }
    }
}
