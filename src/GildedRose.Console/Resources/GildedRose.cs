using System.Collections.Generic;
using GildedRose.Console.Resources.Items;

namespace GildedRose.Console.Resources
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
