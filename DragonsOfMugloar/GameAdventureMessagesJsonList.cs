using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonsOfMugloar
{
    public class GameAdventureMessagesJsonList
    {

     public GameAdventureMessages[] messages { get; set; }
        

        public class GameAdventureMessages
        {
            public string adId { get; set; }
            public string message { get; set; }
            public int reward { get; set; }
            public int expiresIn { get; set; }
            //seda välja pole api dokumentatsioonis kirjeldatud, kui valida sellise väljaga adventure, siis viskab http400.
            public object encrypted { get; set; }
            public string probability { get; set; }
        }

    }
}
