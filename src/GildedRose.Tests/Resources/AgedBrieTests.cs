using System.Collections.Generic;
using System.Linq;
using GildedRose.Console.Resources;
using GildedRose.Console.Resources.Items;
using NUnit.Framework;

namespace GildedRose.Tests.Resources
{
    [TestFixture]
    public class AgedBrieTests
    {
        private TheGildedRose _shop;

        [SetUp]
        public void Init()
        {
            _shop = new TheGildedRose(new List<NormalItem>
            {
                new AgedBrie {Name = "Aged Brie", SellIn = 10, Quality = 20},
            });
        }

        [Test]
        public void UpdateQuality_IncreaseByOne()
        {
            _shop.Update();
            Assert.That(_shop.Items.First().Quality, Is.EqualTo(21));
        }

        [Test]
        public void UpdateSellIn_ReduceByOne()
        {
            _shop.Update();
            Assert.That(_shop.Items.First().SellIn, Is.EqualTo(9));
        }

        [Test]
        public void UpdateQuality_Max50()
        {
            for (var i = 0; i < 100; i++)
            {
                _shop.Update();
            }

            Assert.That(_shop.Items.First().Quality, Is.EqualTo(50));
        }
    }
}
