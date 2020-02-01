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

        public NormalItem(int sellIn, int quality)
        {
            // initial values for today
            SellIn = sellIn;
            Quality = quality;
        }
        public virtual void EndOfDayUpdate()
        {
            SellIn = SellIn - 1;
            if (SellIn < 0) qualityReductionFactor = qualityReductionFactor * 2;
            Quality = Quality - qualityReductionFactor;
            // reset to zero if below
            if (Quality < 1) Quality = 0;
        }
    }
}
