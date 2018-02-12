using System.Collections.Generic;

namespace GildedRose.Console.Resources.Items
{
    public class TheGildedRose
    {
        public IList<NormalItem> Items;

        public TheGildedRose(IList<NormalItem> items)
        {
            Items = items;
        }

        public void Update()
        {
            foreach (var item in Items)
            {
                item.Update();
            }
        }
    }
}
