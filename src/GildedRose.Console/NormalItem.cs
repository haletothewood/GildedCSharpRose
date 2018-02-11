using System;
namespace GildedRose.Console
{
    public class NormalItem : Item
    {
        public virtual void Update()
        {
            if (!Perished()) {
                Quality--;
                if (OutOfDate())
                {
                    Quality--;
                }
            }
            SellIn--;
        }

        public bool Perished() => Quality == 0;
        public bool OutOfDate() => SellIn <= 0;
    }
}
