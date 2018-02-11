using System.Collections.Generic;

namespace GildedRose.Console
{
    public class TheGildedRose
    {
        public IList<NormalItem> Items;

        public TheGildedRose(List<NormalItem> items)
        {
            Items = items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                Items[i].Update();
            }
        }
    }
}
