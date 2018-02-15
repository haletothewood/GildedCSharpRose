using System.Collections.Generic;
using System.Linq;
using GildedRose.Console.Resources;
using GildedRose.Console.Resources.Items;
using NUnit.Framework;

namespace GildedRose.Tests.Resources
{
    [TestFixture]
    public class BackstageTests
    {
        private TheGildedRose _shop;

        [SetUp]
        public void Init()
        {
            _shop = new TheGildedRose(new List<NormalItem>
            {
                new Backstage {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 6},
            });
        }

        [Test]
        public void UpdateQuality_IncreaseByOne()
        {
            _shop.Update();
            Assert.That(_shop.Items.First().Quality, Is.EqualTo(7));
        }

        [Test]
        public void UpdateSellIn_ReducebyOne()
        {
            _shop.Update();
            Assert.That(_shop.Items.First().SellIn, Is.EqualTo(14));
        }

        [Test]
        public void UpdateQuality_IncreaseByTwoIfLessThanTenDays()
        {
            for (var i = 0; i < 6; i++)
            {
                _shop.Update();
            }

            Assert.That(_shop.Items.First().Quality, Is.EqualTo(13));
        }

        [Test]
        public void UpdateQuality_IncreaseByTwoIfLessThanFiveDays()
        {
            for (var i = 0; i < 11; i++)
            {
                _shop.Update();
            }

            Assert.That(_shop.Items.First().SellIn, Is.EqualTo(4));
            Assert.That(_shop.Items.First().Quality, Is.EqualTo(24));
        }

        [Test]
        public void UpdateQuality_DropsToZeroWhenExpired()
        {
            for (var i = 0; i < 16; i++)
            {
                _shop.Update();
            }

            Assert.That(_shop.Items.First().Quality, Is.EqualTo(0));
            Assert.That(_shop.Items.First().SellIn, Is.EqualTo(-1));
        }
    }
}
