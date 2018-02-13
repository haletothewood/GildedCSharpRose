using System.Collections.Generic;
using GildedRose.Console.Resources;
using GildedRose.Console.Resources.Items;
using NUnit.Framework;

namespace GildedRose.Tests.Resources
{
    [TestFixture]
    public class AgedBrieTests
    {
        public TheGildedRose Shop;

        [SetUp]
        public void Init()
        {
            Shop = new TheGildedRose(new List<NormalItem>
            {
                new AgedBrie {Name = "Aged Brie", SellIn = 10, Quality = 20},
            });
        }

        [Test]
        public void UpdateQuality_IncreaseByOne()
        {
            Shop.Update();
            Assert.That(Shop.Items[0].Quality, Is.EqualTo(21));
        }

        [Test]
        public void UpdateSellIn_ReduceByOne()
        {
            Shop.Update();
            Assert.That(Shop.Items[0].SellIn, Is.EqualTo(9));
        }

        [Test]
        public void UpdateQuality_Max50()
        {
            for (var i = 0; i < 100; i++)
            {
                Shop.Update();
            }

            Assert.That(Shop.Items[0].Quality, Is.EqualTo(50));
        }
    }
}
