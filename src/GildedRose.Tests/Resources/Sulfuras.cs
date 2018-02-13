using System.Collections.Generic;
using GildedRose.Console.Resources;
using GildedRose.Console.Resources.Items;
using NUnit.Framework;

namespace GildedRose.Tests.Resources
{
    [TestFixture]
    public class SulfurasTests
    {
        public TheGildedRose Shop;

        [SetUp]
        public void Init()
        {
            Shop = new TheGildedRose(new List<NormalItem>
            {
                new Sulfuras {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
            });
        }

        [Test]
        public void UpdatedQuality_DoesNotChange()
        {
            for (var i = 0; i < 100; i++)
            {
                Shop.Update();
            }

            Assert.That(Shop.Items[0].Quality, Is.EqualTo(80));
        }

        [Test]
        public void UpdatedSellIn_DoesNotChange()
        {
            for (var i = 0; i < 100; i++)
            {
                Shop.Update();
            }

            Assert.That(Shop.Items[0].SellIn, Is.EqualTo(0));
        }
    }
}