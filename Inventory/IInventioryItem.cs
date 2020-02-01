﻿namespace Inventory
{
    public interface IInventioryItem
    {
        int Quality { get; }
        int SellIn {get; }

        void EndOfDayUpdate(int sellIn,int quality);
        string GetEndOfDayValues();
    }
}
