using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3.Records
{
    public class Customer : IRecord
    {
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
