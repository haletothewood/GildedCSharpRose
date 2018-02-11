using System.Collections.Generic;

namespace GildedRose.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var Itinerary = new ItemGenerator();

            var Shop = new TheGildedRose(Itinerary.GetList());

            Shop.UpdateQuality();

            System.Console.ReadKey();
        }

    }
}