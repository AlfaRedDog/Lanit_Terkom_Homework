using System;
using System.Collections.Generic;
using HW2.MenuOut;
using HW3.CRUD;
using HW3.Records;

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
                MenuOutput.ColorWriteLine(ConsoleColor.Yellow, "4 - Work with ShopDB");
                MenuOutput.ColorWriteLine(ConsoleColor.Yellow, "exit - Close programm");
                   
                Console.ForegroundColor = ConsoleColor.Magenta;
                string choose = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Yellow;

                switch (choose)
                {
                    case "1": FibonacciMenu(); break;
                    case "2": ReadFileMenu(); break;
                    case "3": ReadURLMenu(); break;
                    case "4": CRUDDatabaseMenu(); break;
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

        public void CRUDDatabaseMenu()
        {
            SomeDelegat sd = new SomeDelegat(CRUDDatabaseMenu);
            try
            {
                List<string> tables = CRUD.tables;
                tables.Remove("sysdiagrams");

                for (int i = 1; i <= tables.Count; i++)
                {
                    MenuOutput.ColorWriteLine(ConsoleColor.Yellow, $"{i} - {tables[i - 1]}");
                }

                Int32.TryParse(PrintRequestTakeResponse("Choose code of the table:"), out int choice);
                string tableName = "";

                if ((choice <= tables.Count) && (choice > 0))
                {
                    tableName = tables[choice - 1];
                }
                else
                {
                    MenuOutput.ColorWriteLine(ConsoleColor.Red, "Wrong code of the table");
                    ContinueActions(sd);
                }

                MenuOutput.ColorWriteLine(ConsoleColor.Yellow, $"1 - SELECT * FROM {tableName} WHERE !column!=!value!");
                MenuOutput.ColorWriteLine(ConsoleColor.Yellow, $"2 - UPDATE {tableName} SET !column!=!value! WHERE Id = !id!");
                MenuOutput.ColorWriteLine(ConsoleColor.Yellow, $"3 - DELETE FROM {tableName} WHERE !column!=!value!");
                MenuOutput.ColorWriteLine(ConsoleColor.Yellow, $"4 - INSERT INTO {tableName} VALUES (");
                MenuOutput.ColorWriteLine(ConsoleColor.Yellow, $"5 - SELECT * FROM {tableName}");
                MenuOutput.ColorWriteLine(ConsoleColor.Yellow, $"6 - User Query with SELECT or DELETE or INSERT or UPDATE");
                Int32.TryParse(PrintRequestTakeResponse("Choose code of the table:"), out choice);
                
                CRUD crud = new();
                List<string> columns = crud.GetColumns(tableName);
                if ((choice < 4) && (choice > 0))
                {
                    for (int i = 0; i < columns.Count; i++)
                    {
                        MenuOutput.ColorWriteLine(ConsoleColor.Yellow, $"{i} - {columns[i]}");
                    }
                    bool flag = Int32.TryParse(PrintRequestTakeResponse("Choose code of the !column!:"), out int index);
                    if((index >= columns.Count) || (index < 0) || (!flag))
                    {
                        MenuOutput.ColorWriteLine(ConsoleColor.Red, "Wrong code of column");
                        ContinueActions(sd);
                    }

                    string columnName = columns[index];
                    string value = PrintRequestTakeResponse("Enter !value!");
                    if(ReferenceEquals(value, null))
                    {
                        MenuOutput.ColorWriteLine(ConsoleColor.Red, "value cannot be empty");
                        ContinueActions(sd);
                    }

                    if (choice == 1)
                    {
                        MenuOutput.PrintList(crud.GetColumns(tableName), ConsoleColor.Green);
                        MenuOutput.PrintListOfIRecord(crud.ReadRecord(value, columnName, tableName));
                        MenuOutput.ColorWriteLine(ConsoleColor.Yellow, "Operation succesful");
                    }
                    if (choice == 2)
                    {
                        Guid.TryParse(PrintRequestTakeResponse("Enter Id to update:"), out Guid id);
                        if(id == Guid.Empty)
                        {
                            MenuOutput.ColorWriteLine(ConsoleColor.Red, "Wrong id format");
                            ContinueActions(sd);
                        }
                        crud.UpdateRecord(id, columnName, value, tableName);
                        MenuOutput.ColorWriteLine(ConsoleColor.Yellow, "Operation succesful");
                    }
                    if (choice == 3)
                    {
                        crud.DeleteRecord(value, columnName, tableName);
                        MenuOutput.ColorWriteLine(ConsoleColor.Yellow, "Operation succesful");
                    }

                }
                else if (choice == 4)
                {
                    List<string> values = new();
                    for (int i = 0; i < columns.Count; i++)
                    {
                        values.Add(PrintRequestTakeResponse($"Enter {columns[i]} value: "));
                    }
                    crud.CreateRecord(crud.ParseListToIRecord(tableName, values), tableName);
                    MenuOutput.ColorWriteLine(ConsoleColor.Yellow, "Operation succesful");

                }
                else if(choice == 5)
                {
                    MenuOutput.PrintList(crud.GetColumns(tableName), ConsoleColor.Green);
                    MenuOutput.PrintListOfIRecord(crud.ReadRecord(0, "", tableName, $"SELECT * FROM {tableName}"));
                    //написать корректно
                    MenuOutput.ColorWriteLine(ConsoleColor.Yellow, "Operation succesful");

                }else if(choice == 6)
                {
                    List<IRecord> records = crud.AnyQueryCrud(PrintRequestTakeResponse("Enter sql query"), tableName);

                    if(!ReferenceEquals(records, null))
                    {
                        MenuOutput.PrintListOfIRecord(records);
                    }
                    MenuOutput.ColorWriteLine(ConsoleColor.Yellow, "Operation succesful");
                }
                else
                {
                    MenuOutput.ColorWriteLine(ConsoleColor.Red, "Wrong code of operation");
                }
                ContinueActions(sd);
            }
            catch(Exception ex)
            {
                MenuOutput.PrintInfoException("SQL exception", ex);
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
