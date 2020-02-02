using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory
{
    public class BackstagePasses : NormalItem
    {
        public BackstagePasses() { }

        public override void EndOfDayUpdate(int sellIn, int quality)
        {
            // initial values for today
            SellIn = sellIn;
            Quality = quality;
            //recalc for tomorrow
            SellIn = SellIn - 1;
            if (SellIn < 0)
            { Quality = 0; }
            else if (SellIn < 5)
            {
                Quality = Quality + 3;
            }
            else if (sellIn < 10)
            {
                Quality = Quality + 2;
            }
            else
            {
                Quality++;
            }
            // reset to zero if below
            if (Quality < 1) Quality = 0;
        }

        public override string GetEndOfDayValues()
        {
            return $"Backstage Passes {SellIn} {Quality}";
        }
    }
}
