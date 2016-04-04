using System;
using System.Diagnostics;
using System.IO;
using GildedRose.Console;
using NUnit.Framework;

namespace GildedRose.Tests
{
    public class GoldenTests
    {
        [Test]
        public void GuildedRoseTest()
        {
            var stringWriter = new StringWriter();
            System.Console.SetOut(stringWriter);
            Program.UpdateAndPrintItems();

            Assert.AreEqual(@"OMGHAI!
+5 Dexterity Vest|19|9
Aged Brie|1|1
Elixir of the Mongoose|6|4
Sulfuras, Hand of Ragnaros|80|0
Backstage passes to a TAFKAL80ETC concert|21|14
Conjured Mana Cake|5|2
",
                stringWriter.ToString());

        }
    }
}