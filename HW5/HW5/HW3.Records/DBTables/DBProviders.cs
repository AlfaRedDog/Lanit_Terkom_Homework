using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace HW3.Models.DBTables
{
    public class DBProviders
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Adress { get; set; }
    }

    public class DBProvidersConfiguration : IEntityTypeConfiguration<DBProviders>
    {
        public void Configure(EntityTypeBuilder<DBProviders> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Providers");
        }
    }
}
