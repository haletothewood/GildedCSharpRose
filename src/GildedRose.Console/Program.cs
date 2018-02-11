using System.Collections.Generic;

namespace GildedRose.Console
{
    public class Program
    {
        public IList<NormalItem> Items;

        public Program(List<NormalItem> items)
        {
            Items = items;
        }

        public static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var items = new List<NormalItem>
            {
                new NormalItem {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new AgedBrie {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new NormalItem {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new NormalItem {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new NormalItem
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
                new NormalItem {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };

            var app = new Program(items);

            app.UpdateQuality();

            System.Console.ReadKey();
        }

        public void UpdateQuality()
        {

            for (var i = 0; i < Items.Count; i++)
                switch (Items[i].Name)
                {
                    case "Aged Brie":
                        Items[i].Update();
                        break;
                    default:
                        if (Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (Items[i].Quality > 0)
                            {
                                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                                {
                                    Items[i].Quality = Items[i].Quality - 1;
                                }
                            }
                        }
                        else
                        {
                            if (Items[i].Quality < 50)
                            {
                                Items[i].Quality = Items[i].Quality + 1;

                                if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                                {
                                    if (Items[i].SellIn < 11)
                                    {
                                        if (Items[i].Quality < 50)
                                        {
                                            Items[i].Quality = Items[i].Quality + 1;
                                        }
                                    }

                                    if (Items[i].SellIn < 6)
                                    {
                                        if (Items[i].Quality < 50)
                                        {
                                            Items[i].Quality = Items[i].Quality + 1;
                                        }
                                    }
                                }
                            }
                        }

                        if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                        {
                            Items[i].SellIn = Items[i].SellIn - 1;
                        }

                        if (Items[i].SellIn < 0)
                        {
                            if (Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                            {
                                if (Items[i].Quality > 0)
                                {
                                    if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                                    {
                                        Items[i].Quality = Items[i].Quality - 1;
                                    }
                                }
                            }
                            else
                            {
                                Items[i].Quality = Items[i].Quality - Items[i].Quality;
                            }
                        }
                        break;

                }
        }
    }
}