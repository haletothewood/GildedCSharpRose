using System.Collections.Generic;
using GildedRose.Console;
using GildedRose.Console.Resources.Items;
using NUnit.Framework;

namespace GildedRose.Tests.Resources
{
    [TestFixture]
    public class SulfurasTests
    {
        [Test]
        public void UpdatedQuality_DoesNotChange()
        {
            var shop = new TheGildedRose(new List<NormalItem>
            {
                new Sulfuras {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
            });
            
            for (var i = 0; i < 100; i++)
            {
                shop.Update();
            }

            Assert.That(shop.Items[0].Quality, Is.EqualTo(80));
        }

        [Test]
        public void UpdatedSellIn_DoesNotChange()
        {
            var shop = new TheGildedRose(new List<NormalItem>
            {
                new Sulfuras {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
            });

            for (var i = 0; i < 100; i++)
            {
                shop.Update();
            }

            Assert.That(shop.Items[0].SellIn, Is.EqualTo(0));
        }
    }
}