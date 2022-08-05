using System;
using System.Collections.Generic;

namespace HW3.Records
{
    public class Provider : IRecord
    {
        public Provider(List<string> values)
        {
            Id = Guid.Parse(values[0]);
            Name = values[1];
            Adress = values[2];
        }

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
