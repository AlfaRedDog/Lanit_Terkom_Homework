using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3.Records
{
    public class Order : IRecord
    {
        public Order(Guid id_item, Guid id_customer, int amount)
        {
            Id = Guid.NewGuid();
            Id_item = id_item;
            Id_customer = id_customer;
            Amount = amount;
        }

        public Guid Id { get; set; }

        public Guid Id_item { get; set; }

        public Guid Id_customer { get; set; }

        public int Amount { get; set; }
    }
}
