using DataAcess.Datatables;
using HW3.Models.DBTables;
using System.Collections.Generic;
using System.Linq;
using System;

namespace HW4.CRUDEntity.Data
{
    public class OrdersRepository
    {
        private readonly DBShopContext _context;

        public OrdersRepository()
        {
            _context = new DBShopContext(new Microsoft.EntityFrameworkCore.DbContextOptions<DBShopContext>());
        }

        public void Add(DBOrders order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public void Delete(DBOrders order)
        {
            _context.Orders.Remove(order);
            _context.SaveChanges();
        }

        public void Update(DBOrders order, string value, string column)
        {
            DBOrders result = _context.Orders.FirstOrDefault(c => c.Id == order.Id);
            _context.Orders.Attach(result);

            switch (column)
            {
                case "Id": result.Id = Guid.Parse(value); break;
                case "Id_customer": result.Id_customer = Guid.Parse(value); break;
                case "Id_item": result.Id_item = Guid.Parse(value); break;
                case "Amount": result.Amount = Int32.Parse(value); break;
                //default: MenuOutput.ColorWriteLine(ConsoleColor.Red, "Wrong name of column, enter again"); return;
            }

            _context.SaveChanges();
        }

        public List<DBOrders> Read(string value, string column)
        {
            List<DBOrders> result = new();
            switch (column)
            {
                case "Id": result = _context.Orders.Where(x => x.Id == Guid.Parse(value)).ToList(); break;
                case "Id_customer": result = _context.Orders.Where(x => x.Id_customer == Guid.Parse(value)).ToList(); break;
                case "Id_item": result = _context.Orders.Where(x => x.Id_item == Guid.Parse(value)).ToList(); break;
                case "Amount": result = _context.Orders.Where(x => x.Amount == Int32.Parse(value)).ToList(); break;
                //default: MenuOutput.ColorWriteLine(ConsoleColor.Red, "Wrong name of column, enter again"); break;
            }
            return result;
        }
    }
}
