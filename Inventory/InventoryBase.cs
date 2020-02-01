using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory
{
    public abstract class InventoryBase : IInventioryItem
    {
        public int Quality { get; private set; }
        public int SellIn { get; private set; }

        public InventoryBase(int sellIn, int quality)
        {
            // initial values for today
            SellIn = sellIn;
            Quality = quality;
        }
        public virtual void EndOfDayUpdate()
        {

        }
    }
}
