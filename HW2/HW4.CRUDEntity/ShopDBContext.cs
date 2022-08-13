using Microsoft.EntityFrameworkCore;
using HW3.Models;

namespace HW4.CRUDEntity
{
    public class ShopDBContext : DbContext
    {
        public DbSet<Provider> Providers {get; set;}

        public DbSet<Item> Items { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }

        public ShopDBContext(DbContextOptions<ShopDBContext> options) : base(options)
        {
            Database.Migrate();
        }
        /*public List<string> GetTables()
        {
            List<string> tables = new List<string>();

            foreach (var prop in this.GetType().GetProperties())
            {
                if(prop.Name == "Database")
                    return tables;
                tables.Add(prop.Name);
            }
            return tables;
        }
        */
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\sqlexpress;Database=ShopDB;Trusted_Connection=True");
        }
    }
}
