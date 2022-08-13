using HW3.Models;
using HW2.MenuOut;

namespace HW4.CRUDEntity.Data
{
    public class OrdersRepository
    {
        private readonly ShopDBContext _context;

        public OrdersRepository()
        {
            _context = new ShopDBContext(new Microsoft.EntityFrameworkCore.DbContextOptions<ShopDBContext>());
        }

        public void Add(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public void Delete(Order order)
        {
            _context.Orders.Remove(order);
            _context.SaveChanges();
        }

        public void Update(Order order, string value, string column)
        {
            Order result = _context.Orders.FirstOrDefault(c => c.Id == order.Id);
            _context.Orders.Attach(result);

            switch (column)
            {
                case "Id": result.Id = Guid.Parse(value); break;
                case "Id_customer": result.Id_customer = Guid.Parse(value); break;
                case "Id_item": result.Id_item = Guid.Parse(value); break;
                case "Amount": result.Amount = Int32.Parse(value); break;
                default: MenuOutput.ColorWriteLine(ConsoleColor.Red, "Wrong name of column, enter again"); return;
            }

            _context.SaveChanges();
        }

        public List<Order> Read(string value, string column)
        {
            List<Order> result = new();
            switch (column)
            {
                case "Id": result = _context.Orders.Where(x => x.Id == Guid.Parse(value)).ToList(); break;
                case "Id_customer": result = _context.Orders.Where(x => x.Id_customer == Guid.Parse(value)).ToList(); break;
                case "Id_item": result = _context.Orders.Where(x => x.Id_item == Guid.Parse(value)).ToList(); break;
                case "Amount": result = _context.Orders.Where(x => x.Amount == Int32.Parse(value)).ToList(); break;
                default: MenuOutput.ColorWriteLine(ConsoleColor.Red, "Wrong name of column, enter again"); break;
            }
            return result;
        }
    }
}
