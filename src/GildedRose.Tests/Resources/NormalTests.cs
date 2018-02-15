using System.Collections.Generic;
using System.Linq;
using GildedRose.Console.Resources;
using GildedRose.Console.Resources.Items;
using NUnit.Framework;

namespace GildedRose.Tests.Resources
{
    [TestFixture]
    public class UpdateItemsTests
    {
        public TheGildedRose Shop;

        [SetUp]
        public void Init()
        {
            Shop = new TheGildedRose(new List<NormalItem>
            {
                new NormalItem {Name = "Normal", SellIn = 10, Quality = 20},
            });
        }

        [Test]
        public void UpdatedQuality_ReduceByOne()
        { 
            Shop.Update();

            Assert.That(Shop.Items.First().Quality, Is.EqualTo(19));
        }

        [Test]
        public void UpdatedSellIn_ReduceByOne()
        {
            Shop.Update();

            Assert.That(Shop.Items.First().SellIn, Is.EqualTo(9));
        }

        [Test]
        public void UpdatedQuality_ReducesbyTwoIfSellInExpired()
        {

            for (var i = 0; i < 11; i++)
            {
                Shop.Update();
            }

            Assert.That(Shop.Items.First().Quality, Is.EqualTo(8));
        }

        [Test]
        public void UpdatedQuality_NoLowerThanZero()
        {
            for (var i = 0; i < 100; i++)
            {
                Shop.Update();
            }

            Assert.That(Shop.Items.First().Quality, Is.EqualTo(0));
        }   
    }
}