using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory
{
    public class NormalItem : IInventioryItem
    {
        public int Quality { get; protected set; }
        public int SellIn { get; protected set; }

        protected int qualityReductionFactor = 1;

        public NormalItem()
        {   
        }

        public virtual void EndOfDayUpdate(int sellIn, int quality)
        {
            // initial values for today
            SellIn = sellIn;
            Quality = quality;
            //recalc for tomorrow
            SellIn = SellIn - 1;
            if (SellIn < 0) qualityReductionFactor = qualityReductionFactor * 2;
            Quality = Quality - qualityReductionFactor;
            // reset to zero if below
            if (Quality < 1) Quality = 0;
            // reset to 50 if above
            if (Quality > 50) Quality = 50;
        }
        public virtual string GetEndOfDayValues()
        {
            return $"Normal Item {SellIn} {Quality}";
        }
    }
}
