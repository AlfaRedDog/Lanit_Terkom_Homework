using Microsoft.EntityFrameworkCore;
using HW3.Models.DBTables;

namespace DataAcess.Datatables
{
    public class DBShopContext : DbContext
    {
        public DbSet<DBProviders> Providers { get; set; }

        public DbSet<DBItems> Items { get; set; }

        public DbSet<DBCustomers> Customers { get; set; }

        public DbSet<DBOrders> Orders { get; set; }

        public DBShopContext(DbContextOptions<DBShopContext> options) : base(options)
        {
            Database.Migrate(); /// узнать где должен находится migrate
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\sqlexpress;Database=ShopDB;Trusted_Connection=True");
        }
    }
}
