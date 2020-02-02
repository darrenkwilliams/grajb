using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory
{
    public interface IInventoryItemFactory
    {
        IInventioryItem GetItem(string itemName);
    }
}
