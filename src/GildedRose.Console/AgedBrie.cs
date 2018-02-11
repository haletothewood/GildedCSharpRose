using System;
namespace GildedRose.Console
{
    public class AgedBrie : NormalItem
    {
        public override void Update() {
            UpdateQuality();
            SellIn--;
        }

        private void UpdateQuality()
        {
            if (!MaxQuality()) {
                Quality++;
            }
        }

        private bool MaxQuality() => Quality == 50;
    }
}
