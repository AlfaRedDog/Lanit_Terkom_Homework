using System;

namespace HW3.Records
{
    public class Item : IRecord
    {
        public Item(Guid id_provider, int amount, int price)
        {
            Amount = amount;
            Price = price;
            Id = Guid.NewGuid();
            Id_provider = id_provider;
            Expitation_date = DateTime.Now;
        }
        public Guid Id { get; set; }

        public Guid Id_provider { get; set; }

        public int Amount { get; set; }
        
        public int Price { get; set; }

        public DateTime Expitation_date { get; set; }
    }
}
