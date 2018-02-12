using System.Collections.Generic;
using GildedRose.Console;
using NUnit.Framework;

namespace GildedRose.Tests.Resources
{
    [TestFixture]
    public class UpdateItemsTests
    {
        [Test]
        public void UpdatedQuality_ReduceByOne()
        {
            var shop = new TheGildedRose(new List<NormalItem>
            {
                new NormalItem {Name = "Normal", SellIn = 10, Quality = 20},
            });
            shop.Update();

            Assert.That(shop.Items[0].Quality, Is.EqualTo(19));
        }

        [Test]
        public void UpdatedSellIn_ReduceByOne()
        {
            var shop = new TheGildedRose(new List<NormalItem>
            {
                new NormalItem {Name = "Normal", SellIn = 10, Quality = 20},
            });
            shop.Update();

            Assert.That(shop.Items[0].SellIn, Is.EqualTo(9));
        }

        [Test]
        public void UpdatedQuality_ReducesbyTwoIfSellInExpired()
        {
            var shop = new TheGildedRose(new List<NormalItem>
            {
                new NormalItem {Name = "Normal", SellIn = 10, Quality = 20},
            });

            for (var i = 0; i < 11; i++)
            {
                shop.Update();
            }

            Assert.That(shop.Items[0].Quality, Is.EqualTo(8));
        }

        [Test]
        public void UpdatedQuality_NoLowerThanZero()
        {
            var shop = new TheGildedRose(new List<NormalItem>
            {
                new NormalItem {Name = "Normal", SellIn = 10, Quality = 20},
            });

            for (var i = 0; i < 100; i++)
            {
                shop.Update();
            }

            Assert.That(shop.Items[0].Quality, Is.EqualTo(0));
        }   
    }
}