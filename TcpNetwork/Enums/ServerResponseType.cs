using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TCPNetwork.Enums
{
    public enum ServerResponseType : int
    {
        PlainText,
        ContactsList, // maybe rooms
        FullUpdate
    }
}
