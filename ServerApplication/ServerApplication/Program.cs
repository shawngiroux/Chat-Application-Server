using System;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;

/// <summary>
/// Name: Shawn Giroux
/// Date: January 11th, 2016
/// Summary: Entry into program.  Bulk of the code is held
/// in the RunServer.cs back o
/// </summary>

namespace ServerApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            RunServer server = new RunServer();
            server.startServer();
            Console.ReadKey();
        }
    }
}
