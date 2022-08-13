using HW2;
using HW2.MenuOut;
using HW3.Models;
using HW4.CRUDEntity;
using HW4.CRUDEntity.Data;
using System;
//Menu menu = new();
//menu.MainMenu();
ShopDBContext context = new ShopDBContext(new Microsoft.EntityFrameworkCore.DbContextOptions<ShopDBContext>());
/*
CustomersRepository customers = new();
customers.GetColumns();

MenuOutput.PrintList(context.GetTables());
Customer customer = new Customer("Mikhail", "Chesnokov", "SPB");
customers.Add(customer);
MenuOutput.PrintListOfCustomer(customers.Read($"{customer.Id}", "Id"));
customers.Update(customer, "spb", "Adress");
Console.WriteLine();
MenuOutput.PrintListOfCustomer(customers.Read($"{customer.Id}", "Id"));
Console.WriteLine();
customers.Delete(customer);
MenuOutput.PrintListOfCustomer(customers.Read("Mikhail", "Name"));
*/
//c.CreateRecord(new Provider("snidfnis", "nfsduinfs"), "Providers");