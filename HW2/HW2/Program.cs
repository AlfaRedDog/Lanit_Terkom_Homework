using HW3.CRUD;
using HW3.Records;
using System;

namespace HW2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new();
            //menu.MainMenu();
            CRUD cRUD = new();
            IRecord customer = new Customer("Mikhail", "Chesnokov", "Saint-Petersburg");
            IRecord provider = new Provider("RosTeleCom", "HELL");
            IRecord item = new Item(provider.Id, 5, 20);
            IRecord order = new Order(item.Id, customer.Id, 3);


            //cRUD.CreateRecord(item, "Items");
            //cRUD.CreateRecord(customer, "Customers");
            //cRUD.CreateRecord(provider, "Providers");
            //cRUD.CreateRecord(order, "Orders");

            //cRUD.ReadRecord<Guid>(item.Id, "Id", "Items");
            //cRUD.UpdateRecord<int>(item.Id, "Amount", 3, "Items");
            //cRUD.ReadRecord<Guid>(item.Id, "Id", "Items");
            //cRUD.DeleteRecord<int>(5, "Amount", "Items");
            cRUD.ClearTable("Orders");
            cRUD.ClearTable("Items");
            cRUD.ClearTable("Customers");
            cRUD.ClearTable("Providers");
        }
    }
}
