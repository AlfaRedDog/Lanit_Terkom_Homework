using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HW2.MenuOut;

namespace HW2
{
    public class FileReader : IFileReader
    {
        public void ReadAllLines(string path)
        {
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string line = sr.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    while (line != null)
                    {
                        Console.WriteLine(line);
                        line = sr.ReadLine();
                    }
                    sr.Close();
                }
            }
            catch (FileNotFoundException ex)
            {
                MenuOutput.PrintInfoException("Wrong file, try again", ex);
            }
            catch (DirectoryNotFoundException ex)
            {
                MenuOutput.PrintInfoException("Wrong directory, try again", ex);
            }
        }

        public void ReadNLines(string path, int n)
        {
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string line = sr.ReadLine();

                    for (int i = 0; i < n && line != null; i++)
                    { 
                        MenuOutput.ColorWriteLine(ConsoleColor.Green, line);
                        line = sr.ReadLine();
                    }
                    sr.Close();
                }
            }
            catch(ArgumentException ex)
            {
                MenuOutput.PrintInfoException("Wrong path, try again", ex);
            }
            catch(FileNotFoundException ex)
            {
                MenuOutput.PrintInfoException("Wrong file, try again", ex);
            }
            catch(DirectoryNotFoundException ex)
            {
                MenuOutput.PrintInfoException("Wrong directory, try again", ex);
            }
        }
    }
}
