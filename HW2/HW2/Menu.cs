using System;
using System.IO;
using System.Net.Http;
using System.Net.Sockets;
using HW2.fib;

//убрать static в методах Menu
namespace HW2
{
    class Menu
    {
        delegate void SomeDelegat();

        public void RunMainMenu()
        {
            try
            {
                bool mainflag = true;

                while (mainflag)
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
                        case "1": RunFibonacciMenu(); break;
                        case "2": RunReadFileMenu(); break;
                        case "3": RunReadURLMenu(); break;
                        case "exit": 
                            MenuOut.ColorWriteLine(ConsoleColor.Yellow, "Goodbye)"); 
                            mainflag = false; 
                            return;
                        default: MenuOut.ColorWriteLine(ConsoleColor.Red, "wrong code operation, try again"); break;
                    }
                }
            }
            catch (Exception ex)
            {
                MenuOut.PrintInfoException("Unhandled exception", ex);
            }
        }

        public void RunFibonacciMenu()
        {
            Int32.TryParse(PrintRequestTakeResponse("Enter number:"), out int n);

            Fibonacci fibonacci = new Fibonacci();
            fibonacci.PrintFibonacciSequence(n);

            SomeDelegat sd = new SomeDelegat(RunFibonacciMenu);
            ContinueActions(sd);
        }

        public void RunReadFileMenu()
        {
            SomeDelegat sd = new SomeDelegat(RunReadFileMenu);

            try
            {
                string path = PrintRequestTakeResponse("Enter path to file:");
                if (path.Equals("main menu"))
                {
                    return;
                }
                string countLines = PrintRequestTakeResponse("Enter the number of lines you want to count: count / all");

                FileReader fileReader = new FileReader();

                if (countLines.Equals("all"))
                {
                    fileReader.ReadAllLines(path);
                }

                if (Int32.TryParse(countLines, out int a) && a >= 0)
                    fileReader.ReadNLines(path, a);
                else
                    throw new FormatException();
            }
            catch (FormatException ex)
            {
                MenuOut.PrintInfoException("Wrong format of count lines, try again", ex);
            }
            catch (DirectoryNotFoundException ex)
            {
                MenuOut.PrintInfoException("Wrong directory, try again", ex);
            }
            catch (FileNotFoundException ex)
            {
                MenuOut.PrintInfoException("Wrong file, try again", ex);
            }
            catch (ArgumentException ex)
            {
                MenuOut.PrintInfoException("path is empty, try again", ex);
            }
            finally
            {
                ContinueActions(sd);
            }
        }

        public void RunReadURLMenu()
        {
            SomeDelegat sd = new SomeDelegat(RunReadURLMenu);
            try
            {
                MenuOut.ColorWriteLine(ConsoleColor.Yellow, "Enter website URL:");
                //https://google.com
                //https://alfareddog.github.io/

                Console.ForegroundColor = ConsoleColor.Magenta;
                string urlAdress = Console.ReadLine();
                if (urlAdress.Equals("main menu")) 
                { 
                    return; 
                }

                MenuOut.ColorWriteLine(ConsoleColor.Yellow, "Enter path to file:");
                //C:\Users\mikhail\Desktop\Lanit_Terkom_Homework\HW2\HW2\HTMLfile.html

                Console.ForegroundColor = ConsoleColor.Magenta;
                string path = Console.ReadLine();

                if (path.Equals("main menu")) 
                { 
                    return;
                }

                HTMLReader reader = new HTMLReader();
                reader.ReadAndWriteHtmlToFile(urlAdress, path);
            }
            catch (InvalidOperationException ex)
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
            catch (SocketException ex)
            {
                MenuOut.PrintInfoException("The host of this url is unknown, try again", ex);
            }
            catch (AggregateException ex)
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

        public void RunCRUD()
        {

        }

        private void ContinueActions(SomeDelegat sd)
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

        private string PrintRequestTakeResponse(string info)
        {
            MenuOut.ColorWriteLine(ConsoleColor.Yellow, info);

            Console.ForegroundColor = ConsoleColor.Magenta;
            string answer = Console.ReadLine();

            return answer;
        }
    }
}
