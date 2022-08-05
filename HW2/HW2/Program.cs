namespace HW2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new();
            menu.MainMenu();
            /*
            CRUD cRUD = new();
            IRecord customer = new Customer("Mikhal", "Chesnokov", "Saint-Petersburg");
            IRecord provider = new Provider("RosTeleCom", "HLL");
            IRecord item = new Item(provider.Id, 4, 20);
            IRecord order = new Order(item.Id, customer.Id, 10);

            cRUD.CreateRecord(customer, "Customers");
            cRUD.CreateRecord(provider, "Providers");
            cRUD.CreateRecord(item, "Items");;
            cRUD.CreateRecord(order, "Orders");

            //cRUD.ReadRecord<Guid>(item.Id, "Id", "Items");
            //cRUD.UpdateRecord<int>(item.Id, "Amount", 3, "Items");
            //cRUD.ReadRecord<Guid>(item.Id, "Id", "Items");
            //cRUD.DeleteRecord<int>(5, "Amount", "Items");
            //cRUD.ClearTable("Orders");
            //cRUD.ClearTable("Items");
            //cRUD.ClearTable("Customers");
            //cRUD.ClearTable("Providers");
            */
        }
    }
}
