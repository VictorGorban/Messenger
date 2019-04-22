using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TCPNetwork.Enums;

namespace TcpNetwork.ServerResponses
{
    class ServerResponseHeader
    {
        public StatusCode StatusCode { get; set; }
        public ServerResponseType ServerResponseType { get; set; }
    }
}
