using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using GildedRose.Console;
using NUnit.Framework;

namespace GildedRose.Tests
{
    [TestFixture]
    public class UpdateItemsTests
    {
        [Test]
        public void NormalItem_UpdatedQuality()
        {
            var items = new List<Item>
            {
                new Item {Name = "Normal", SellIn = 10, Quality = 20},
            };

            var app = new Program(items);

            app.UpdateQuality();

            /*Quality reduces by 1*/
            Assert.That(app.Items[0].Quality, Is.EqualTo(19));

            /*SellIn reduces by 1*/
            Assert.That(app.Items[0].SellIn, Is.EqualTo(9));

            for (var i = 0; i < 10; i++)
            {
                app.UpdateQuality();
            }

            /*Quality reduces at twice the rate if SellIn is less than zero*/
            Assert.That(app.Items[0].Quality, Is.EqualTo(8));

            /*SellIn reduces by 1 each day*/
            Assert.That(app.Items[0].SellIn, Is.EqualTo(-1));

            for (var i = 0; i < 100; i++)
            {
                app.UpdateQuality();
            }

            /*Quality cannot be less than zero*/
            Assert.That(app.Items[0].Quality, Is.EqualTo(0));
        }

        [Test]
        public void AgedBrieItem_UpdatedQuality()
        {
            var items = new List<Item>
            {
                new Item {Name = "Aged Brie", SellIn = 10, Quality = 20},
            };

            var app = new Program(items);

            app.UpdateQuality();

            /*Quality increases by 1*/
            Assert.That(app.Items[0].Quality, Is.EqualTo(21));

            /*SellIn reduces by 1*/
            Assert.That(app.Items[0].SellIn, Is.EqualTo(9));

            for (var i = 0; i < 100; i++)
            {
                app.UpdateQuality();
            }

            /*Quality cannot be more than 50*/
            Assert.That(app.Items[0].Quality, Is.EqualTo(50));

            /*SellIn reduces by 1 each day*/
            Assert.That(app.Items[0].SellIn, Is.EqualTo(-91));
        }
    }
}