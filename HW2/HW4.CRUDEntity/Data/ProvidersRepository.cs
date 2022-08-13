using HW3.Models;
using HW2.MenuOut;

namespace HW4.CRUDEntity.Data
{
    public class ProvidersRepository
    {
        private readonly ShopDBContext _context;

        public ProvidersRepository()
        {
            _context = new ShopDBContext(new Microsoft.EntityFrameworkCore.DbContextOptions<ShopDBContext>());
        }

        public void Add(Provider Provider)
        {
            _context.Providers.Add(Provider);
            _context.SaveChanges();
        }

        public void Delete(Provider Provider)
        {
            _context.Providers.Remove(Provider);
            _context.SaveChanges();
        }

        public void Update(Provider Provider, string value, string column)
        {
            Provider result = _context.Providers.FirstOrDefault(c => c.Id == Provider.Id);
            _context.Providers.Attach(result);

            switch (column)
            {
                case "Id": result.Id = Guid.Parse(value); break;
                case "Name": result.Name = value; break;
                case "Adress": result.Adress = value; break;
                default: MenuOutput.ColorWriteLine(ConsoleColor.Red, "Wrong name of column, enter again"); return;
            }

            _context.SaveChanges();
        }

        public List<Provider> Read(string value, string column)
        {
            List<Provider> result = new();
            switch (column)
            {
                case "Id": result = _context.Providers.Where(x => x.Id == Guid.Parse(value)).ToList(); break;
                case "Name": result = _context.Providers.Where(x => x.Name == value).ToList(); break;
                case "Adress": result = _context.Providers.Where(x => x.Adress == value).ToList(); break;
                default: MenuOutput.ColorWriteLine(ConsoleColor.Red, "Wrong name of column, enter again"); break;
            }
            return result;
        }
    }
}
