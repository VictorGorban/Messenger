using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TcpNetwork.ServerResponses.Classes;

namespace TcpNetwork.ServerResponses
{
    class FullUpdate
    {
        public ContactOrRoomWithUnreadMessages[] ContactOrRoomWithUnreadMessages { get; set; }
    }
}
