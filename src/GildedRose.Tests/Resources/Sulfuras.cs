using System.Collections.Generic;
using System.Linq;
using GildedRose.Console.Resources;
using GildedRose.Console.Resources.Items;
using NUnit.Framework;

namespace GildedRose.Tests.Resources
{
    [TestFixture]
    public class SulfurasTests
    {
        private TheGildedRose _shop;

        [SetUp]
        public void Init()
        {
            _shop = new TheGildedRose(new List<NormalItem>
            {
                new Sulfuras {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
            });
        }

        [Test]
        public void UpdatedQuality_DoesNotChange()
        {
            for (var i = 0; i < 100; i++)
            {
                _shop.Update();
            }

            Assert.That(_shop.Items.First().Quality, Is.EqualTo(80));
        }

        [Test]
        public void UpdatedSellIn_DoesNotChange()
        {
            for (var i = 0; i < 100; i++)
            {
                _shop.Update();
            }

            Assert.That(_shop.Items.First().SellIn, Is.EqualTo(0));
        }
    }
}