using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TcpNetwork.ServerResponses.Classes
{
    class ContactOrRoomWithUnreadMessages
    {
        public string ContactOrRoomName { get; set; }
        public string[] UnreadMessages { get; set; }

    }
}
