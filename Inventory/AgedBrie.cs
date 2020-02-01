using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory
{
    public class AgedBrie : NormalItem
    {

        public AgedBrie() 
        {
        }

        public override void EndOfDayUpdate(int sellIn, int quality)
        {
            // initial values for today
            SellIn = sellIn;
            Quality = quality;

            //recalc for tomorrow
            SellIn = SellIn - 1;            
            Quality++;
            // reset to 50 if above
            if (Quality > 50) Quality = 50;
        }
    }

}
