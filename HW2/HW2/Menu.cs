using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;

// Вопросы к своему коду:
// На сколько плохо то что я вызываю в ContinueActions рекурсивно методы, и можно ли это как-то исправить
// как сделать так чтобы catch с одинаковым кодом не повторялись
// что плохо с кодстайлом

namespace HW2
{
    internal class Menu
    {
        delegate void SomeDelegat();

        public void MainMenu()
        {
            bool mainflag = true;
            while (mainflag)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Choose Operation:");
                    Console.WriteLine("1 - Find Fibonacci number");
                    Console.WriteLine("2 - Read File");
                    Console.WriteLine("3 - Get HTML code from website");
                    Console.WriteLine("exit - Close programm");
                    Console.ResetColor();
                    
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    string choose = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Yellow;

                    switch (choose)
                    {
                        case "1": FibonacciMenu(); break;
                        case "2": ReadFileMenu(); break;
                        case "3": ReadURL(); break;
                        case "exit": mainflag = false; Console.WriteLine("Goodbye)"); break;
                        default: Console.WriteLine("wrong code operation, try again"); break;
                    }
                }
                catch(ExecutionEngineException ex) // Изменить на Exeption
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                }
            }
        }

        public void FibonacciMenu()
        {
            try
            {
                int N = Int32.Parse(PrintChooseTakeAnswer("Enter number:"));
                Fibonacci fibonacci = new Fibonacci();
                fibonacci.PrintFibonacciSequence(N);

                SomeDelegat sd = new SomeDelegat(FibonacciMenu);
                ContinueActions(sd);
            }
            catch(FormatException ex)
            {
                PrintInfoException("Wrong format of number, try again", ex);
                FibonacciMenu();
            }
        }

        public void ReadFileMenu()
        {
            try
            {
                string path = PrintChooseTakeAnswer("Enter path to file:");
                if (path.Equals("main menu"))
                    return;
                string countLines = PrintChooseTakeAnswer("Enter the number of lines you want to count: count / all");

                FileReader fileReader = new FileReader();
                SomeDelegat sd = new SomeDelegat(ReadFileMenu);

                if (countLines.Equals("all"))
                {
                    fileReader.ReadAllLines(path);
                    ContinueActions(sd);
                }

                fileReader.ReadNLines(path, Int32.Parse(countLines)); // change on TryParse later
                ContinueActions(sd);
            }
            catch (FormatException ex)
            {
                PrintInfoException("Wrong format of count lines, try again", ex);
                ReadFileMenu();
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;   
                Console.WriteLine("Wrong directory, try again");
                ReadFileMenu();
            }
            catch(FileNotFoundException ex)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Wrong file, try again");
                ReadFileMenu();
            }
            catch(ArgumentException ex)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("path is empty, try again");
                ReadFileMenu();
            }
        }

        public void ReadURL()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Enter website URL:");
                //https://google.com
                Console.ForegroundColor = ConsoleColor.Magenta;
                string urlAdress = Console.ReadLine();
                if (urlAdress.Equals("main menu")) return;

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Enter path to file:");
                //C:\Users\mikhail\Desktop\Lanit_Terkom_Homework\HW2\HW2\HTMLfile.html
                Console.ForegroundColor = ConsoleColor.Magenta;
                string path = Console.ReadLine();
                if (path.Equals("main menu")) return;

                HTMLReader reader = new HTMLReader();
                reader.ReadAndWriteHtmlToFile(urlAdress, path);

                SomeDelegat sd = new SomeDelegat(ReadURL);
                ContinueActions(sd);
            }
            catch(InvalidOperationException ex)
            {
                PrintInfoException("Wrong URL, try again", ex);
                ReadURL();
            }
            catch (ArgumentException ex)
            {
                PrintInfoException("Only 'http' and 'https' schemes are allowed", ex);
                ReadURL();
            }
            catch (HttpRequestException ex)
            {
                PrintInfoException("The host of this url is unknown, try again", ex);
                ReadURL();
            }
            catch(SocketException ex)
            {
                PrintInfoException("The host of this url is unknown, try again", ex);
                ReadURL();
            }
            catch(AggregateException ex)
            {
                PrintInfoException("Wrong URL, try again", ex);
                ReadURL();
            }
            catch (DirectoryNotFoundException ex)
            {
                PrintInfoException("Wrong directory, try again", ex);
                ReadFileMenu();
            }
            catch (FileNotFoundException ex)
            {
                PrintInfoException("Wrong file, try again", ex);
                ReadFileMenu();
            }
        }

        private void ContinueActions(SomeDelegat sd)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Continue actions? Y/N");
            Console.ForegroundColor = ConsoleColor.Magenta;
            string choose = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Yellow;

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

                default: Console.WriteLine("Wrong format answer, try again"); ContinueActions(sd); break;
            }
        }

        private string PrintChooseTakeAnswer(string info)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(info);

            Console.ForegroundColor = ConsoleColor.Magenta;
            string answer = Console.ReadLine();

            return answer;
        }

        private void PrintInfoException(string text, Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.StackTrace);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(text);
        }
    }
}
