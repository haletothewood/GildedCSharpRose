using System.Collections.Generic;
using GildedRose.Console.Resources;
using GildedRose.Console.Resources.Items;
using NUnit.Framework;

namespace GildedRose.Tests.Resources
{
    [TestFixture]
    public class BackstageTests
    {
        public TheGildedRose Shop;

        [SetUp]
        public void Init()
        {
            Shop = new TheGildedRose(new List<NormalItem>
            {
                new Backstage {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 6},
            });
        }

        [Test]
        public void UpdateQuality_IncreaseByOne()
        {
            Shop.Update();
            Assert.That(Shop.Items[0].Quality, Is.EqualTo(7));
        }

        [Test]
        public void UpdateSellIn_ReducebyOne()
        {
            Shop.Update();
            Assert.That(Shop.Items[0].SellIn, Is.EqualTo(14));
        }

        [Test]
        public void UpdateQuality_IncreaseByTwoIfLessThanTenDays()
        {
            for (var i = 0; i < 6; i++)
            {
                Shop.Update();
            }

            Assert.That(Shop.Items[0].Quality, Is.EqualTo(13));
        }

        [Test]
        public void UpdateQuality_IncreaseByTwoIfLessThanFiveDays()
        {
            for (var i = 0; i < 11; i++)
            {
                Shop.Update();
            }

            Assert.That(Shop.Items[0].SellIn, Is.EqualTo(4));
            Assert.That(Shop.Items[0].Quality, Is.EqualTo(24));
        }

        [Test]
        public void UpdateQuality_DropsToZeroWhenExpired()
        {
            for (var i = 0; i < 16; i++)
            {
                Shop.Update();
            }

            Assert.That(Shop.Items[0].Quality, Is.EqualTo(0));
            Assert.That(Shop.Items[0].SellIn, Is.EqualTo(-1));
        }
    }
}
