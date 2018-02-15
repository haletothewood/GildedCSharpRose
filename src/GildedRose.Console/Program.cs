using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using GildedRose.Console.Resources;
using GildedRose.Console.Resources.Items;

namespace GildedRose.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var itinerary = new ItemGenerator();

            var shop = new TheGildedRose(itinerary.Items);

            shop.Update();

            System.Console.ReadKey();
        }
    }
}