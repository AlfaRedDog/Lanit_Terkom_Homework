﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    internal interface IHTMLReader
    {
        void ReadAndWriteHtmlToFile(string urlAdress, string path);
    }
}
