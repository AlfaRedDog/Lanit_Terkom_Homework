using System;
using System.Collections.Generic;

namespace HW3.Records
{
    public class Customer : IRecord
    {
        public Customer(List<string> values)
        {
            Id = Guid.Parse(values[0]);
            Name = values[1];
            Surename = values[2];
            Adress = values[3];
        }
        public Customer(string name, string surename, string adress) 
        {
            Id = Guid.NewGuid();
            Name = name;
            Surename = surename;
            Adress = adress;
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Surename { get; set; }

        public string Adress { get; set; }
    }
}
