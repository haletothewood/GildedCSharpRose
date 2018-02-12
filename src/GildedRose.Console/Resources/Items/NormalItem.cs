namespace GildedRose.Console.Resources.Items
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

        private const int BestBefore = 0;
        public bool Perished() => Quality == BestBefore;
        public bool OutOfDate() => SellIn <= 0;
    }
}
