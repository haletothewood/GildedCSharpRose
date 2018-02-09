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

            /*Quality reduces at twice the rate if SellIn is less than zero*/
            for (var i = 0; i < 10; i++)
            {
                app.UpdateQuality();
            }

            Assert.That(app.Items[0].Quality, Is.EqualTo(8));

            /*SellIn reduces by 1 each day*/
            Assert.That(app.Items[0].SellIn, Is.EqualTo(-1));

            /*Quality cannot be less than zero*/
            for (var i = 0; i < 100; i++)
            {
                app.UpdateQuality();
            }

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

            /*Quality cannot be more than 50*/
            for (var i = 0; i < 100; i++)
            {
                app.UpdateQuality();
            }

            Assert.That(app.Items[0].Quality, Is.EqualTo(50));

            /*SellIn reduces by 1 each day*/
            Assert.That(app.Items[0].SellIn, Is.EqualTo(-91));
        }

        [Test]
        public void BackstageItem_UpdatedQuality()
        {
            var items = new List<Item>
            {
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 6},
            };

            var app = new Program(items);

            app.UpdateQuality();

            /*Quality increases by 1*/
            Assert.That(app.Items[0].Quality, Is.EqualTo(7));

            /*SellIn reduces by 1*/
            Assert.That(app.Items[0].SellIn, Is.EqualTo(14));

            /*Quality increase by two if SellIn is less than 10*/
            for (var i = 0; i < 5; i++)
            {
                app.UpdateQuality();
            }

            Assert.That(app.Items[0].Quality, Is.EqualTo(13));

            /*Quality increase by 3 if SellIn is less than 5*/
            for (var i = 0; i < 5; i++)
            {
                app.UpdateQuality();
            }

            Assert.That(app.Items[0].Quality, Is.EqualTo(24));

            /*Quality drops to zero after the concert*/
            for (var i = 0; i < 5; i++)
            {
                app.UpdateQuality();
            }

            Assert.That(app.Items[0].Quality, Is.EqualTo(0));

            /*SellIn has reduced to less than zero*/
            Assert.That(app.Items[0].SellIn, Is.EqualTo(-1));
        }
    }
}