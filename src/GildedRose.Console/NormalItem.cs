using System;
namespace GildedRose.Console
{
    public class NormalItem : Item
    {
        public virtual void Update()
        {
            DecreaseSellIn();
            UpdateQuality();
            if (SellIn < 0) {
                UpdateQuality();
            }
        }

        private void DecreaseSellIn()
        {
            SellIn--;
        }

        private void UpdateQuality()
        {
            Quality--;
        }
    }
}
