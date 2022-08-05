using HW3.Records;
using System;
using System.Collections.Generic;

namespace HW2.MenuOut
{
    public class MenuOutput
    {
        public static void ColorWriteLine(ConsoleColor color, string messege)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(messege);
            Console.ResetColor();
        }

        public static void ColorWrite(ConsoleColor color, string messege)
        {
            Console.ForegroundColor = color;
            Console.Write(messege);
            Console.ResetColor();
        }

        public static void PrintInfoException(string text, Exception ex)
        {
            ColorWriteLine(ConsoleColor.Red, ex.Message);
            ColorWriteLine(ConsoleColor.Red, ex.StackTrace);

            ColorWriteLine(ConsoleColor.Red, text);
        }

        public static void PrintListOfIRecord(List<IRecord> rows)
        {
            foreach(IRecord row in rows)
            {
                foreach (var prop in row.GetType().GetProperties())
                {
                   ColorWrite(ConsoleColor.Green, $"{prop.GetValue(row, null)} ");
                }
                Console.WriteLine();
            }
        }
    }
}
