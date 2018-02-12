using System.Collections.Generic;
using GildedRose.Console;
using NUnit.Framework;

namespace GildedRose.Tests
{
    [TestFixture]
    public class BackstageTests
    {
        [Test]
        public void AgedBrie_UpdateQuality()
        {
            var items = new List<NormalItem>
            {
                new Backstage {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 6},
            };

            var app = new TheGildedRose(items);

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

            Assert.That(app.Items[0].SellIn, Is.EqualTo(4));
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
