using System;
namespace GildedRose.Console
{
    public class NormalItem : Item
    {
        public virtual void Update()
        {
            SellIn--;
            if (!IsPerished()) {
                Quality--;
                if (OutOfDate())
                {
                    Quality--;
                }
            }
        }

        private bool IsPerished() => Quality == 0;
        private bool OutOfDate() => SellIn < 0;
    }
}
