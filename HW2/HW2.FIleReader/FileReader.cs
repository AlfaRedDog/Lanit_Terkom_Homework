using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                MenuOut.PrintInfoException("Wrong file, try again", ex);
            }
            catch (DirectoryNotFoundException ex)
            {
                MenuOut.PrintInfoException("Wrong directory, try again", ex);
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
                        MenuOut.ColorWriteLine(ConsoleColor.Green, line);
                        line = sr.ReadLine();
                    }
                    sr.Close();
                }
            }
            catch(ArgumentException ex)
            {
                MenuOut.PrintInfoException("Wrong path, try again", ex);
            }
            catch(FileNotFoundException ex)
            {
                MenuOut.PrintInfoException("Wrong file, try again", ex);
            }
            catch(DirectoryNotFoundException ex)
            {
                MenuOut.PrintInfoException("Wrong directory, try again", ex);
            }
        }
    }
}
