using System;
namespace GildedRose.Console
{
    public class Backstage : NormalItem
    {
        public override void Update()
        {
            UpdateQuality();
            SellIn--;
        }

        private void UpdateQuality()
        {
            Quality++;
            if (Within10Days())
            {
                Quality++;
            }
            if (Within5Days())
            {
                Quality += 2;
            }
            if (OutOfDate())
            {
                Quality = 0;
            }
        }

        private bool Within10Days() => SellIn <= 10 && SellIn > 5;
        private bool Within5Days() => SellIn <= 5 && !OutOfDate();
    }
}
