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

        private const int BEST_BEFORE = 0;
        public bool Perished() => Quality == BEST_BEFORE;
        public bool OutOfDate() => SellIn <= 0;
    }
}
