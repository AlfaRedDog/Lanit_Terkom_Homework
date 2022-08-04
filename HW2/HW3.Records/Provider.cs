using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3.Records
{
    public class Provider : IRecord
    {
        public Provider(string name, string adress)
        {
            Id = Guid.NewGuid();
            Name = name;
            Adress = adress;
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Adress { get; set; }
    }
}
