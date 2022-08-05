using System;
using System.Collections.Generic;

namespace HW3.Records
{
    public class Item : IRecord
    {
        public Item(List<string> values)
        {
            Id = Guid.Parse(values[0]);
            Id_provider = Guid.Parse(values[1]);
            Amount = Int32.Parse(values[2]);
            Price = Int32.Parse(values[3]);
            Expitation_date = DateTime.Parse(values[4]);
        }
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
