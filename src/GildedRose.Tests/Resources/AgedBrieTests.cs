using System.Collections.Generic;
using GildedRose.Console;
using GildedRose.Console.Resources.Items;
using NUnit.Framework;

namespace GildedRose.Tests.Resources
{
    [TestFixture]
    public class AgedBrieTests
    {
        [Test]
        public void UpdateQuality_IncreaseByOne()
        {
            var shop = new TheGildedRose(new List<NormalItem>
                {
                    new AgedBrie {Name = "Aged Brie", SellIn = 10, Quality = 20},
                });
            shop.Update();
            Assert.That(shop.Items[0].Quality, Is.EqualTo(21));
        }

        [Test]
        public void UpdateSellIn_ReduceByOne()
        {
            var shop = new TheGildedRose(new List<NormalItem>
                {
                    new AgedBrie {Name = "Aged Brie", SellIn = 10, Quality = 20},
                });
            shop.Update();
            Assert.That(shop.Items[0].SellIn, Is.EqualTo(9));
        }

        [Test]
        public void UpdateQuality_Max50()
        {
            var shop = new TheGildedRose(new List<NormalItem>
                {
                    new AgedBrie {Name = "Aged Brie", SellIn = 10, Quality = 20},
                });

            for (var i = 0; i < 100; i++)
            {
                shop.Update();
            }

            Assert.That(shop.Items[0].Quality, Is.EqualTo(50));
        }
    }
}
