using DataAcess.Datatables;
using HW3.Models.DBTables;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HW4.CRUDEntity.Data
{
    public class CustomersRepository
    {
        private readonly DBShopContext _context;

        public CustomersRepository()
        {
            _context = new DBShopContext(new Microsoft.EntityFrameworkCore.DbContextOptions<DBShopContext>());
        }
        
        public void Add(DBCustomers customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public void Delete(DBCustomers customer)
        {
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }

        public void Update(DBCustomers customer, string value, string column)
        {
            DBCustomers result = _context.Customers.FirstOrDefault(c => c.Id == customer.Id);
            _context.Customers.Attach(result);

            switch (column)
            {
                case "Id": result.Id = Guid.Parse(value); break;
                case "Name": result.Name = value; break;
                case "Surename": result.Surename = value; break;
                case "Adress": result.Adress = value; break;
                //default: MenuOutput.ColorWriteLine(ConsoleColor.Red, "Wrong name of column, enter again"); return;
            }

            _context.SaveChanges();
        }

        public List<DBCustomers> Read(string value, string column)
        {
            List<DBCustomers> result = new();
            switch (column)
            {
                case "Id": result = _context.Customers.Where(x => x.Id == Guid.Parse(value)).ToList(); break;
                case "Name": result = _context.Customers.Where(x => x.Name == value).ToList(); break;
                case "Surename": result = _context.Customers.Where(x => x.Surename == value).ToList(); break;
                case "Adress": result = _context.Customers.Where(x => x.Adress == value).ToList(); break;
                //default: MenuOutput.ColorWriteLine(ConsoleColor.Red, "Wrong name of column, enter again"); break;
            }
            return result;
        }
    }
}
