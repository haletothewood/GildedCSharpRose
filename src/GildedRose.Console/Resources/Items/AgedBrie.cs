namespace GildedRose.Console.Resources.Items
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

        private const int MaxQuality = 50;
        private bool IsMaxQuality() => Quality == MaxQuality;
    }
}
