using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3.Models.Responses
{
    public class ItemResponse
    {
        public int Amount { get; set; }

        public int Price { get; set; }

        public DateTime Expiration_date { get; set; }
    }
}
