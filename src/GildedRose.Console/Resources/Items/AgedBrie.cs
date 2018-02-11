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
            if (!IsMaxQuality()) {
                Quality++;
            }
        }

        private const int MAX_QUALITY = 50;
        private bool IsMaxQuality() => Quality == MAX_QUALITY;
    }
}
