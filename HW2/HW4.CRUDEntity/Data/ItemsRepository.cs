using HW2.MenuOut;
using HW3.Models;

namespace HW4.CRUDEntity.Data
{
    public class ItemsRepository
    {
        private readonly ShopDBContext _context;

        public ItemsRepository()
        {
            _context = new ShopDBContext(new Microsoft.EntityFrameworkCore.DbContextOptions<ShopDBContext>());
        }

         public void Add(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
        }

        public void Delete(Item item)
        {
            _context.Items.Remove(item);
            _context.SaveChanges();
        }

        public void Update(Item item, string value, string column)
        {
            Item result = _context.Items.FirstOrDefault(c => c.Id == item.Id);
            _context.Items.Attach(result);

            switch (column)
            {
                case "Id": result.Id = Guid.Parse(value); break;
                case "Id_provider": result.Id_provider = Guid.Parse(value); break;
                case "Amount": result.Amount = Int32.Parse(value); break;
                case "Price": result.Price = Int32.Parse(value); break;
                case "Expiration_date": result.Expiration_date = DateTime.Parse(value); break;
                default: MenuOutput.ColorWriteLine(ConsoleColor.Red, "Wrong name of column, enter again"); return;
            }

            _context.SaveChanges();
        }

        public List<Item> Read(string value, string column)
        {
            List<Item> result = new();

            switch (column)
            {
                case "Id": result = _context.Items.Where(x => x.Id == Guid.Parse(value)).ToList(); break;
                case "Id_provider": result = _context.Items.Where(x => x.Id_provider == Guid.Parse(value)).ToList(); break;
                case "Amount": result = _context.Items.Where(x => x.Amount == Int32.Parse(value)).ToList(); break;
                case "Price": result = _context.Items.Where(x => x.Price == Int32.Parse(value)).ToList(); break;
                case "Expiration_date": result = _context.Items.Where(x => x.Expiration_date == DateTime.Parse(value)).ToList(); break;
                default: MenuOutput.ColorWriteLine(ConsoleColor.Red, "Wrong name of column, enter again"); break;
            }

            return result;
        }
    }
}
