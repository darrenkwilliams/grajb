using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GildedRose.Models;
using Microsoft.AspNetCore.Mvc;
using Inventory;

namespace GildedRose.Controllers
{
    public class InventoryController : Controller
    {
        private IInventoryItemFactory _inventoryFactory;
        public InventoryController(IInventoryItemFactory inventoryFactory)
        {
            _inventoryFactory = inventoryFactory;
        }

        public IActionResult Index()
        {
            var inventoryModel = new InventoryModel();
            return View(inventoryModel);
        }

        [HttpPost]
        public ActionResult Index(InventoryModel model)
        {
            //initialise model
            ModelState.Clear();
            var inventoryModel = new InventoryModel();
            inventoryModel.InventoryListIn = model.InventoryListIn;
            // get lines
            var lines = model.InventoryListIn.Split("\r\n");

            foreach (string line in lines)
            {
                var itemVars = ParseInputLine(line);
                IInventioryItem item = _inventoryFactory.GetItem(itemVars.Item1.Trim());
                if (item == null)
                {
                    inventoryModel.InventoryListOut += "NO SUCH ITEM<br/>";
                }
                else
                {
                    item.EndOfDayUpdate(itemVars.Item2, itemVars.Item3);
                    inventoryModel.InventoryListOut += item.GetEndOfDayValues() + "<br/>";
                }
            }         
            
            //var inventoryModel = new InventoryModel();
            //inventoryModel.InventoryListOut = "test1<br/>test2";
            return View(inventoryModel);
        }
        private Tuple<string, int, int> ParseInputLine(string line)
        {
            var elements = line.Split(' ');
            if (elements.Count() < 3)
            {
                return new Tuple<string, int, int>("Invalid", 0, 0);
            }

            int quality = 0;
            int.TryParse(elements[elements.Count() - 1], out quality);
            int sellIn = 0;
            int.TryParse(elements[elements.Count() - 2], out sellIn);
            string itemName = String.Join(" ", elements.Take(elements.Count() - 2));
            return new Tuple<string, int, int>(itemName, sellIn, quality);
        }
    }
}