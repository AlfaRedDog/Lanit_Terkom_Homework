using System;
using System.Threading;

namespace HW1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //init
            Potion potion1 = new Potion("Potion1", 3000);
            Potion potion2 = new Potion();

            SpellBook spellBook1 = new SpellBook("Book1", 15, DateTime.Now);
            SpellBook spellBook2 = new SpellBook();

            Invertory user1 = new Invertory("user1", true, 10, potion1, spellBook1);
            Invertory user2 = new Invertory("user2", false, -15, potion2, spellBook2);

            //test
            Console.WriteLine("ReadMap for user1 output: ");
            user1.ReadMap();
            Console.WriteLine("ReadMap for user2 output: ");
            user2.ReadMap();
            Console.WriteLine("");

            Console.WriteLine("Potion.Drink for user1 output:");
            user1.Elixir.Drink(150);
            Console.WriteLine("Potion.Drink for user2 output:");
            user2.Elixir.Drink(150);
            Console.WriteLine("");

            Console.WriteLine("Potion.TopUpDrink for user1 output:");
            user1.Elixir.TopUpDrink(150);
            Console.WriteLine("Potion.TopUpDrink for user2 output:");
            user2.Elixir.TopUpDrink(350);
            Console.WriteLine("");

            Console.WriteLine("Potion.GetVolumeInIiters for user1 output:");
            Console.WriteLine(user1.Elixir.GetVolumeInIiters());
            Console.WriteLine("Potion.GetVolumeInIiters for user1 output:");
            Console.WriteLine(user2.Elixir.GetVolumeInIiters());
            Console.WriteLine("");

            Console.WriteLine("Info about user1 before cleaning:");
            user1.PrintInfo();
            Console.WriteLine("Info about user2 before cleaning:");
            user2.PrintInfo();
            Console.WriteLine("");

            Console.WriteLine("Clean users");
            user1.Clean();
            user2.Clean();
            Console.WriteLine("");

            Console.WriteLine("Info about user1 after cleaning:");
            user1.PrintInfo();
            Console.WriteLine("Info about user2 after cleaning:");
            user2.PrintInfo();
        }
    }
}
