using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using HW2.MenuOut;

namespace HW2
{
    class Menu
    {
        delegate void SomeDelegat();

        public void MainMenu()
        {
            try
            {
                MenuOutput.ColorWriteLine(ConsoleColor.Yellow, "Choose Operation:");
                MenuOutput.ColorWriteLine(ConsoleColor.Yellow, "1 - Find Fibonacci number");
                MenuOutput.ColorWriteLine(ConsoleColor.Yellow, "2 - Read File");
                MenuOutput.ColorWriteLine(ConsoleColor.Yellow, "3 - Get HTML code from website");
                MenuOutput.ColorWriteLine(ConsoleColor.Yellow, "exit - Close programm");
                   
                Console.ForegroundColor = ConsoleColor.Magenta;
                string choose = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Yellow;

                switch (choose)
                {
                    case "1": FibonacciMenu(); break;
                    case "2": ReadFileMenu(); break;
                    case "3": ReadURLMenu(); break;
                    case "exit": MenuOutput.ColorWriteLine(ConsoleColor.Yellow, "Goodbye)"); return;
                    default: MenuOutput.ColorWriteLine(ConsoleColor.Red, "wrong code operation, try again"); break;
                }

                MainMenu();
            }
            catch(Exception ex)
            {
                MenuOutput.PrintInfoException("Unhandled exception", ex);
            }
        }

        public void FibonacciMenu()
        {
            Int32.TryParse(PrintRequestTakeResponse("Enter number:"), out int N);
            Fibonacci fibonacci = new Fibonacci();
            fibonacci.PrintFibonacciSequence(N);

            SomeDelegat sd = new SomeDelegat(FibonacciMenu);
            ContinueActions(sd);
        }

        public void ReadFileMenu()
        {
            SomeDelegat sd = new SomeDelegat(ReadFileMenu);
            try
            {
                string path = PrintRequestTakeResponse("Enter path to file:");
                if (path.Equals("main menu"))
                    return;
                string countLines = PrintRequestTakeResponse("Enter the number of lines you want to count: count / all");

                FileReader fileReader = new FileReader();

                if (countLines.Equals("all"))
                {
                    fileReader.ReadAllLines(path);
                }

                if (Int32.TryParse(countLines, out int a))
                    fileReader.ReadNLines(path, a);
            }
            catch (FormatException ex)
            {
                MenuOutput.PrintInfoException("Wrong format of count lines, try again", ex);
            }
            finally
            {
                ContinueActions(sd);
            }
        }

        public void ReadURLMenu()
        {
            SomeDelegat sd = new SomeDelegat(ReadURLMenu);
            try
            {
                MenuOutput.ColorWriteLine(ConsoleColor.Yellow, "Enter website URL:");
                //https://google.com
                //https://alfareddog.github.io/

                Console.ForegroundColor = ConsoleColor.Magenta;
                string urlAdress = Console.ReadLine();
                if (urlAdress.Equals("main menu")) return;

                MenuOutput.ColorWriteLine(ConsoleColor.Yellow, "Enter path to file:");
                //C:\Users\mikhail\Desktop\Lanit_Terkom_Homework\HW2\HW2\HTMLfile.html

                Console.ForegroundColor = ConsoleColor.Magenta;
                string path = Console.ReadLine();

                if (path.Equals("main menu")) return;

                HTMLReader reader = new HTMLReader();
                reader.ReadAndWriteHtmlToFile(urlAdress, path);
            }
            finally
            {
                ContinueActions(sd);
            }
        }

        private void ContinueActions(SomeDelegat sd)
        {
            MenuOutput.ColorWriteLine(ConsoleColor.Yellow, "Continue actions? Y/N");

            Console.ForegroundColor = ConsoleColor.Magenta;
            string choose = Console.ReadLine();

            switch (choose)
            {
                case "N":
                case "n":
                case "No":
                case "no": return;

                case "Y":
                case "y":
                case "Yes":
                case "yes": sd.Invoke(); break;

                default: MenuOutput.ColorWriteLine(ConsoleColor.Red, "Wrong format answer, try again"); ContinueActions(sd); break;
            }
        }

        private string PrintRequestTakeResponse(string info)
        {
            MenuOutput.ColorWriteLine(ConsoleColor.Yellow, info);

            Console.ForegroundColor = ConsoleColor.Magenta;
            string answer = Console.ReadLine();

            return answer;
        }
    }
}
