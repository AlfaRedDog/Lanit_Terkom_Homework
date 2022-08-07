using System;
using System.Collections.Generic;

namespace HW3.Records
{
    public class Order : IRecord
    {
        public Order(List<string> values)
        {
            Id = Guid.Parse(values[0]);
            Id_item = Guid.Parse(values[1]);
            Id_customer = Guid.Parse(values[2]);
            Amount = Int32.Parse(values[3]);
        }

        public Order(Guid id_item, Guid id_customer, int amount)
        {
            Id = Guid.NewGuid();
            Id_item = id_item;
            Id_customer = id_customer;
            Amount = amount;
        }

        public Guid Id { get; set; }

        public Guid Id_customer { get; set; }

        public Guid Id_item { get; set; }

        public int Amount { get; set; }
    }
}
