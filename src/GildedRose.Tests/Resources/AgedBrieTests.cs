using System.Collections.Generic;
using GildedRose.Console;
using NUnit.Framework;

namespace GildedRose.Tests
{
    [TestFixture]
    public class AgedBrieTests
    {
        public TheGildedRose shop;

        [Test]
        public void UpdateQuality_ByOne()
        {
            var shop = new TheGildedRose(new List<NormalItem>
                {
                    new AgedBrie {Name = "Aged Brie", SellIn = 10, Quality = 20},
                });
            shop.UpdateQuality();
            Assert.That(shop.Items[0].Quality, Is.EqualTo(21));
        }

        [Test]
        public void UpdateSellIn_ReduceByOne()
        {
            var shop = new TheGildedRose(new List<NormalItem>
                {
                    new AgedBrie {Name = "Aged Brie", SellIn = 10, Quality = 20},
                });
            shop.UpdateQuality();
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
                shop.UpdateQuality();
            }

            Assert.That(shop.Items[0].Quality, Is.EqualTo(50));
        }
    }
}
