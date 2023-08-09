using System.Collections.Generic;

namespace GildedRose
{
    public class GildedRose
    {
        private readonly IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                if (Items[i].Name != "Sulfuras, Hand of Ragnaros") Items[i].SellIn = Items[i].SellIn - 1;

                if (Items[i].Name != "Aged Brie" && Items[i].Name != "Backstage passes to a TAFKAL80ETC concert" && Items[i].Name != "Sulfuras, Hand of Ragnaros")
                {
                    if (Items[i].Quality > 0) Items[i].Quality--;
                    if (Items[i].SellIn < 0 && Items[i].Quality > 0) Items[i].Quality--;

                    if (Items[i].Name.Contains("Conjured"))
                    {
                        if (Items[i].Quality > 0) Items[i].Quality--;
                        if (Items[i].SellIn < 0 && Items[i].Quality > 0) Items[i].Quality--;
                    }
                }
                else
                {
                    if (Items[i].Name == "Aged Brie" && Items[i].Quality < 50)
                    {
                        Items[i].Quality++;
                        if (Items[i].SellIn < 0 && Items[i].Quality < 50) Items[i].Quality++;
                    }
                    else if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (Items[i].Quality < 50) Items[i].Quality++;

                        if (Items[i].SellIn < 10 && Items[i].Quality < 50) Items[i].Quality++;

                        if (Items[i].SellIn < 5 && Items[i].Quality < 50) Items[i].Quality++;

                        if (Items[i].SellIn < 0) Items[i].Quality = 0;
                    }
                }
            }
        }
    }
}
