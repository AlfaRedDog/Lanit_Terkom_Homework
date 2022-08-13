using DataAcess.Datatables;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace HW5
{
    public class Program
    {
        public static void Main()
        {
            DBShopContext dBShopContext = new DBShopContext(new Microsoft.EntityFrameworkCore.DbContextOptions<DBShopContext>());
            CreateHostBuilder().Build().Run();
        }

        public static IHostBuilder CreateHostBuilder() =>
            Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
