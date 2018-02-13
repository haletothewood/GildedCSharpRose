using System.Collections.Generic;
using GildedRose.Console.Resources;
using GildedRose.Console.Resources.Items;
using NUnit.Framework;

namespace GildedRose.Tests.Resources
{
    [TestFixture]
    public class ConjuredItemTests
    {
        public TheGildedRose Shop;

        [SetUp]
        public void Init()
        {
            Shop = new TheGildedRose(new List<NormalItem>
            {
                new Conjured {Name = "Conjured", SellIn = 10, Quality = 20},
            });
        }
        [Test]
        public void UpdatedQuality_ReduceByOne()
        {
            Shop.Update();

            Assert.That(Shop.Items[0].Quality, Is.EqualTo(18));
        }

        [Test]
        public void UpdatedSellIn_ReduceByTwo()
        {
            Shop.Update();

            Assert.That(Shop.Items[0].SellIn, Is.EqualTo(9));
        }

        [Test]
        public void UpdatedQuality_ReducesbyFourIfSellInExpired()
        {
            for (var i = 0; i < 11; i++)
            {
                Shop.Update();
            }

            Assert.That(Shop.Items[0].Quality, Is.EqualTo(16));
        }

        [Test]
        public void UpdatedQuality_NoLowerThanZero()
        {
            for (var i = 0; i < 100; i++)
            {
                Shop.Update();
            }

            Assert.That(Shop.Items[0].Quality, Is.EqualTo(0));
        }
    }
}
