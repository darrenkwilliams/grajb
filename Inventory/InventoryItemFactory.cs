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
                case "Backstage Passes":
                    return new BackstagePasses();
                case "Conjured":
                    return new Conjured();
                case "Sulfuras":
                    return new Sulfuras();
                default:
                    //TODO - implement some not found concrete class? return null and let calling program deal with action...
                    return null;
            }
        }
    }
}
