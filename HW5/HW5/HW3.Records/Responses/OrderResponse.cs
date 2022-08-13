using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3.Models.Responses
{
    public class OrderResponse
    {
        public Guid Id { get; set; }

        public Guid Id_item { get; set; }

        public int Amount { get; set; }
    }
}
