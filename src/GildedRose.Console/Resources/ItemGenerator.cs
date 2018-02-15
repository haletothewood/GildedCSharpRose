using System.Collections.Generic;
using GildedRose.Console.Resources.Items;

namespace GildedRose.Console.Resources
{
    public class ItemGenerator
    {
        public List<NormalItem> Items { get; }

        public ItemGenerator()
        {
            Items = new List<NormalItem>
            {
                new NormalItem {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new AgedBrie {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new NormalItem {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new Sulfuras {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new Backstage
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
                new NormalItem {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };
        }
    }
}
