using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TcpNetwork.ServerResponses.Classes
{
    class ContactOrRoomContact
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public bool IsRoom { get; set; }
        public string Status { get; set; } // online users if room; status if not room.
    }
}
