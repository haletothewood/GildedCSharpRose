namespace GildedRose.Console.Resources.Items
{
    public class NormalItem : Item
    {
        private const int MinimumQuality = 0;
        private const int SellByDate = 0;

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
        public bool Perished() => Quality == MinimumQuality;
        public bool OutOfDate() => SellIn <= SellByDate;
    }
}
