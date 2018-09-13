using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonsOfMugloar
{
    public class GameShopItemsJson
    {


    public ShopItems[] shopItems { get; set; }
        

        public class ShopItems
        {
            public string id { get; set; }
            public string name { get; set; }
            public int cost { get; set; }
        }

    }
}
