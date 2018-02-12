using System.Collections.Generic;
using GildedRose.Console;
using NUnit.Framework;

namespace GildedRose.Tests.Resources
{
    [TestFixture]
    public class BackstageTests
    {
        [Test]
        public void UpdateQuality_IncreaseByOne()
        {
            var shop = new TheGildedRose(new List<NormalItem>
            {
                new Backstage {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 6},
            });
            shop.Update();
            Assert.That(shop.Items[0].Quality, Is.EqualTo(7));
        }

        [Test]
        public void UpdateSellIn_ReducebyOne()
        {
            var shop = new TheGildedRose(new List<NormalItem>
            {
                new Backstage {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 6},
            });
            shop.Update();
            Assert.That(shop.Items[0].SellIn, Is.EqualTo(14));
        }

        [Test]
        public void UpdateQuality_IncreaseByTwoIfLessThanTenDays()
        {
            var shop = new TheGildedRose(new List<NormalItem>
            {
                new Backstage {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 6},
            });

            for (var i = 0; i < 6; i++)
            {
                shop.Update();
            }

            Assert.That(shop.Items[0].Quality, Is.EqualTo(13));
        }

        [Test]
        public void UpdateQuality_IncreaseByTwoIfLessThanFiveDays()
        {
            var shop = new TheGildedRose(new List<NormalItem>
            {
                new Backstage {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 6},
            });

            for (var i = 0; i < 11; i++)
            {
                shop.Update();
            }

            Assert.That(shop.Items[0].SellIn, Is.EqualTo(4));
            Assert.That(shop.Items[0].Quality, Is.EqualTo(24));
        }

        [Test]
        public void UpdateQuality_DropsToZeroWhenExpired()
        {
            var shop = new TheGildedRose(new List<NormalItem>
            {
                new Backstage {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 6},
            });

            for (var i = 0; i < 16; i++)
            {
                shop.Update();
            }

            Assert.That(shop.Items[0].Quality, Is.EqualTo(0));
            Assert.That(shop.Items[0].SellIn, Is.EqualTo(-1));
        }
    }
}
