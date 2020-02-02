using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory
{
    public class InventoryItemFactory : IInventoryItemFactory
    {
        public IInventioryItem GetItem(string itemName)
        {
            switch (itemName)
            {
                case "Normal Item":
                    return new NormalItem();
                case "Aged Brie":
                    return new AgedBrie();
                case "Backstage passes":
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
