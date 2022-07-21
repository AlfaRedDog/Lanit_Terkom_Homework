using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1
{
    internal class SpellBook
    {
        public string Title { get; set; }
        public  int Pages { get; set; }
        public DateTime CreatedAt { get; set; }
        public SpellBook(string title, int pages, DateTime createdAt)
        {
            Title = title;
            Pages = pages;
            CreatedAt = createdAt;
        }
        public SpellBook()
        {
            Title = "DEFAULT";
            Pages = 0;
            CreatedAt = DateTime.Now;
        }
    }
}
