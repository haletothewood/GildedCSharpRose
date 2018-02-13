using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GildedRose.Console.Resources.Items;
using NUnit.Framework;

namespace GildedRose.Tests.Resources
{
    [TestFixture]
    public class ConjuredItemTests
    {
        [Test]
        public void UpdatedQuality_ReduceByOne()
        {
            var shop = new TheGildedRose(new List<NormalItem>
            {
                new Conjured {Name = "Conjured", SellIn = 10, Quality = 20},
            });
            shop.Update();

            Assert.That(shop.Items[0].Quality, Is.EqualTo(18));
        }

        [Test]
        public void UpdatedSellIn_ReduceByTwo()
        {
            var shop = new TheGildedRose(new List<NormalItem>
            {
                new Conjured {Name = "Conjured", SellIn = 10, Quality = 20},
            });
            shop.Update();

            Assert.That(shop.Items[0].SellIn, Is.EqualTo(9));
        }

        [Test]
        public void UpdatedQuality_ReducesbyFourIfSellInExpired()
        {
            var shop = new TheGildedRose(new List<NormalItem>
            {
                new Conjured {Name = "Conjured", SellIn = 10, Quality = 40},
            });

            for (var i = 0; i < 11; i++)
            {
                shop.Update();
            }

            Assert.That(shop.Items[0].Quality, Is.EqualTo(16));
        }

        [Test]
        public void UpdatedQuality_NoLowerThanZero()
        {
            var shop = new TheGildedRose(new List<NormalItem>
            {
                new Conjured {Name = "Conjured", SellIn = 10, Quality = 20},
            });

            for (var i = 0; i < 100; i++)
            {
                shop.Update();
            }

            Assert.That(shop.Items[0].Quality, Is.EqualTo(0));
        }
    }
}
