using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    internal interface IFileReader
    {
        void ReadNLines(string path, int n);

        void ReadAllLines(string path);
    }
}
