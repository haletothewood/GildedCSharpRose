namespace GildedRose.Console.Resources.Items
{
    public class AgedBrie : NormalItem
    {
        private const int MaxQuality = 50;

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

        private bool IsMaxQuality() => Quality == MaxQuality;
    }
}
