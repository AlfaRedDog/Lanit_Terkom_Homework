using System;

namespace HW1
{
    internal class Potion
    {
        public string Name { get; set; }
        public int Milliliters { get; set; }

        public Potion(string name, int milliliters)
        {
            Name = name;
            Milliliters = milliliters;
        }

        public Potion()
        {
            Name = "DEFAULT";
            Milliliters = 0;
        }

        public void Drink(int count)
        {
            Milliliters -= count;
            Console.WriteLine(Milliliters);
        }

        public void TopUpDrink(int count)
        {
            Milliliters += count;
            Console.WriteLine(Milliliters);
        }

        public double GetVolumeInIiters()
        {
            return Milliliters / 1000.0;
        }
    }
}
