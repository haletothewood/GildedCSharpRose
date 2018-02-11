namespace GildedRose.Console
{
    public class Conjured : NormalItem
    {
        public override void Update()
        {
            if (!Perished())
            {
                Quality -= 2;
                if (OutOfDate())
                {
                    Quality -= 2;
                }
            }
            SellIn--;
        }
    }
}
