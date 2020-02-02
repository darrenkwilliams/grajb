using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory
{
    public class Conjured : NormalItem
    {
        public Conjured() { }

        public override void EndOfDayUpdate(int sellIn, int quality)
        {
            // initial values for today
            SellIn = sellIn;
            Quality = quality;
            //recalc for tomorrow
            SellIn = SellIn - 1;
            // quality reduces twice as fast as normal
            qualityReductionFactor = 2;
            if (SellIn < 0) qualityReductionFactor = qualityReductionFactor * 2;
            Quality = Quality - qualityReductionFactor;
            // reset to zero if below
            if (Quality < 1) Quality = 0;
        }

        public override string GetEndOfDayValues()
        {
            return $"Conjured {SellIn} {Quality}";
        }
    }
}
