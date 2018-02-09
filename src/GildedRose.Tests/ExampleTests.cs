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
        public void UpdatedQuality_QualityIsReducedBy1()
        {
            var items = new List<Item>
            {
                new Item {Name = "Normal", SellIn = 10, Quality = 10},
            };

            var app = new Program(items);

            app.UpdateQuality();
            Assert.That(app.Items[0].Quality, Is.EqualTo(9));
        }
    }
}