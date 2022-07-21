using System;

namespace HW1
{
    internal class Invertory
    {
        public string Map { get; set; }
        public bool Flag { get; set; }
        public int Slots { get; set; }
        public Potion Elixir { get; set; }
        public SpellBook Magic { get; set; }
        public Invertory(string map, bool flag, int slots, Potion drink, SpellBook magic)
        {
            Map = map;
            Flag = flag;
            Slots = slots;
            Elixir = drink;
            Magic = magic;
        }
        public void Clean()
        {
            Map = "";
            Flag = false;
            Slots = 0;
            Elixir = new Potion();
            Magic = new SpellBook();
        }
        public void ReadMap()
        {
            Console.WriteLine(Map);
        }
        public void PrintInfo()
        {
            Console.WriteLine($"{Map} {Flag} {Slots} {Elixir.Name} {Elixir.Milliliters} {Magic.Title} {Magic.Pages} {Magic.CreatedAt}");
        }
    }
}
