using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory
{
    public static class InventoryItemFactory
    {
        public static IInventioryItem GetItem(string itemName)
        {
            switch (itemName)
            {
                case "Normal Item":
                    return new NormalItem();
                case "Aged Brie":
                    return new AgedBrie();
                default:
                    //TODO - implement some not found concrete class?
                    return new NormalItem();
            }
        }
    }
}
