using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory
{
    public class Sulfuras : NormalItem
    {
        public Sulfuras() { }

        public override void EndOfDayUpdate(int sellIn, int quality)
        {
            // initial values for today
            SellIn = sellIn;
            Quality = quality;

            // and no update required but.....
            // reset to 50 if above
            if (Quality > 50) Quality = 50;
        }

        public override string GetEndOfDayValues()
        {
            return $"Sulfuras {SellIn} {Quality}";
        }
    }
}
