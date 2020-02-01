using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory
{
    public class AgedBrie : NormalItem
    {

        public AgedBrie(int sellIn, int quality) : base(sellIn, quality)
        {
        }

        public  override void EndOfDayUpdate()
        {
            SellIn = SellIn - 1;            
            Quality++;
            // reset to 50 if above
            if (Quality > 50) Quality = 50;
        }
    }

}
