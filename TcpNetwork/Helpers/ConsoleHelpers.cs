using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TcpNetwork.Helpers
{
    public static class ConsoleHelpers
    {
        public static void error(string message)
        {
            var oldColor = Console.ForegroundColor;
            var newColor = ConsoleColor.Red;
            Console.ForegroundColor = newColor;
            Console.WriteLine(message);
            Console.ForegroundColor = oldColor;



        }

    }
}
