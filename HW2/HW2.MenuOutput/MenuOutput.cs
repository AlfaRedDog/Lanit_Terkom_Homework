using System;

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
    }
}
