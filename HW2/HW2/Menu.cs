using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;

namespace HW2
{
    static class Menu
    {
        delegate void SomeDelegat();

        public static void MainMenu()
        {
            try
            {
                MenuOut.ColorWriteLine(ConsoleColor.Yellow, "Choose Operation:");
                MenuOut.ColorWriteLine(ConsoleColor.Yellow, "1 - Find Fibonacci number");
                MenuOut.ColorWriteLine(ConsoleColor.Yellow, "2 - Read File");
                MenuOut.ColorWriteLine(ConsoleColor.Yellow, "3 - Get HTML code from website");
                MenuOut.ColorWriteLine(ConsoleColor.Yellow, "exit - Close programm");
                   
                Console.ForegroundColor = ConsoleColor.Magenta;
                string choose = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Yellow;

                switch (choose)
                {
                    case "1": FibonacciMenu(); break;
                    case "2": ReadFileMenu(); break;
                    case "3": ReadURLMenu(); break;
                    case "exit": MenuOut.ColorWriteLine(ConsoleColor.Yellow, "Goodbye)"); return;
                    default: MenuOut.ColorWriteLine(ConsoleColor.Red, "wrong code operation, try again"); break;
                }

                MainMenu();
            }
            catch(Exception ex)
            {
                MenuOut.ColorWriteLine(ConsoleColor.Red, ex.Message);
                MenuOut.ColorWriteLine(ConsoleColor.Red, ex.StackTrace);
            }
        }

        public static void FibonacciMenu()
        {
            Int32.TryParse(PrintRequestTakeResponse("Enter number:"), out int N);
            Fibonacci fibonacci = new Fibonacci();
            fibonacci.PrintFibonacciSequence(N);

            SomeDelegat sd = new SomeDelegat(FibonacciMenu);
            ContinueActions(sd);
        }

        public static void ReadFileMenu()
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
                else
                    throw new FormatException();
            }
            catch (FormatException ex)
            {
                MenuOut.ColorWriteLine(ConsoleColor.Red, "Wrong format of count lines, try again");
            }
            catch (DirectoryNotFoundException ex)
            { 
                MenuOut.ColorWriteLine(ConsoleColor.Red, "Wrong directory, try again");
            }
            catch(FileNotFoundException ex)
            {
                MenuOut.ColorWriteLine(ConsoleColor.Red, "Wrong file, try again");
            }
            catch(ArgumentException ex)
            {
                MenuOut.ColorWriteLine(ConsoleColor.Red, "path is empty, try again");
            }
            finally
            {
                ContinueActions(sd);
            }
        }

        public static void ReadURLMenu()
        {
            SomeDelegat sd = new SomeDelegat(ReadURLMenu);
            try
            {
                MenuOut.ColorWriteLine(ConsoleColor.Yellow, "Enter website URL:");
                //https://google.com
                //https://alfareddog.github.io/

                Console.ForegroundColor = ConsoleColor.Magenta;
                string urlAdress = Console.ReadLine();
                if (urlAdress.Equals("main menu")) return;

                MenuOut.ColorWriteLine(ConsoleColor.Yellow, "Enter path to file:");
                //C:\Users\mikhail\Desktop\Lanit_Terkom_Homework\HW2\HW2\HTMLfile.html

                Console.ForegroundColor = ConsoleColor.Magenta;
                string path = Console.ReadLine();

                if (path.Equals("main menu")) return;

                HTMLReader reader = new HTMLReader();
                reader.ReadAndWriteHtmlToFile(urlAdress, path);
            }
            catch(InvalidOperationException ex)
            {
                MenuOut.PrintInfoException("Wrong URL, try again", ex);
            }
            catch (ArgumentException ex)
            {
                MenuOut.PrintInfoException("Argument excepton", ex);
            }
            catch (HttpRequestException ex)
            {
                MenuOut.PrintInfoException("The host of this url is unknown, try again", ex);
            }
            catch(SocketException ex)
            {
                MenuOut.PrintInfoException("The host of this url is unknown, try again", ex);
            }
            catch(AggregateException ex)
            {
                MenuOut.PrintInfoException("Wrong URL, try again", ex);
            }
            catch (DirectoryNotFoundException ex)
            {
                MenuOut.PrintInfoException("Wrong directory, try again", ex);
            }
            catch (FileNotFoundException ex)
            {
                MenuOut.PrintInfoException("Wrong file, try again", ex);
            }
            finally
            {
                ContinueActions(sd);
            }
        }

        private static void ContinueActions(SomeDelegat sd)
        {
            MenuOut.ColorWriteLine(ConsoleColor.Yellow, "Continue actions? Y/N");

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

                default: MenuOut.ColorWriteLine(ConsoleColor.Red, "Wrong format answer, try again"); ContinueActions(sd); break;
            }
        }

        private static string PrintRequestTakeResponse(string info)
        {
            MenuOut.ColorWriteLine(ConsoleColor.Yellow, info);

            Console.ForegroundColor = ConsoleColor.Magenta;
            string answer = Console.ReadLine();

            return answer;
        }
    }
}
