using System.Collections.Generic;

namespace GildedRose.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var itinerary = new ItemGenerator();

            var shop = new TheGildedRose(itinerary.GetList());

            shop.Update();

            System.Console.ReadKey();
        }

    }
}