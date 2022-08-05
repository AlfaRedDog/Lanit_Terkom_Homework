using System;
using System.Collections.Generic;

namespace HW3.Records
{
    public class Header : IRecord
    {
        Header(List<string> values)
        {
            NameOfColumns = values;
        }
        public Guid Id { get; set; }

        public List<string> NameOfColumns { get; set; }
    }
}
