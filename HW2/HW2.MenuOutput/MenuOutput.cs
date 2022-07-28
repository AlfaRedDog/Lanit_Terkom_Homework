using System;

namespace HW2
{
    public class MenuOut
    {
        public static void ColorWriteLine(ConsoleColor color, string messege)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(messege);
        }

        public static void ColorWrite(ConsoleColor color, string messege)
        {
            Console.ForegroundColor = color;
            Console.Write(messege);
        }

        public static void PrintInfoException(string text, Exception ex)
        {
            ColorWriteLine(ConsoleColor.Red, ex.Message);
            ColorWriteLine(ConsoleColor.Red, ex.StackTrace);

            ColorWriteLine(ConsoleColor.Red, text);
        }
    }
}
