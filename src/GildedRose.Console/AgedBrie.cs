using System;
namespace GildedRose.Console
{
    public class AgedBrie : NormalItem
    {
        public override void Update() {
            DecreaseSellIn();
            IncrementQuality();
        }

        private void DecreaseSellIn() {
            SellIn--;
        }

        private void IncrementQuality()
        {
            if (!MaxQuality()) {
                Quality++;
            }
        }

        private bool MaxQuality() => Quality == 50;
    }
}
