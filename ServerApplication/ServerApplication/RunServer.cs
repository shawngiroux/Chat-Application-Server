using System;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections;

/// <summary>
/// Name: Shawn Giroux
/// Date: January 11th, 2016
/// Summary: A simple chat server that handles multiple clients.
/// </summary>

namespace ServerApplication
{
    class RunServer
    {
        /*******************************************************
         * Declaring variables for later use.
         *******************************************************/

        /* Server info */
        private IPAddress serverIP = IPAddress.Any;
        private int port = 26900;

        /* Used for handling server and clients */
        private ArrayList clientList;
        private TcpListener server;
        private TcpClient client;
        private string connectingClient;
        private Thread listenThread;
        private Thread clientThread;

        /* Reads and writes to server/client */
        private NetworkStream stream;

        public void startServer()
        {
            /*******************************************************
             * Starts the server with a pre-determined IP and port
             * number.  The user is prompted that the server is
             * ready and waiting for connections.
             *******************************************************/
            server = new TcpListener(serverIP, port);
            clientList = new ArrayList();

            server.Start();
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("                              Server Started                ");
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("                         Waiting For Connections            \n");
            listening();
        }
        private void listening()
        {
            while (true)
            {
                /*******************************************************
                 * Keeps the server listening for clients and then
                 * creates a new thread to handle the new client.
                 *******************************************************/
                client = server.AcceptTcpClient();
                clientThread = new Thread(new ParameterizedThreadStart(handleClient));
                clientThread.Start(client);
            }
        }
        private void handleClient(object obj)
        {
            /*******************************************************
             * New client is passed as a parameter, and then we
             * inform the user what IP address the client is
             * connecting from.  We then add that client to a list
             * that will be used to send messages to each client.
             *******************************************************/
            TcpClient newClient = (TcpClient)obj;
            connectingClient = newClient.Client.RemoteEndPoint.ToString();
            Console.WriteLine("Accepted connection from: " + connectingClient);
            clientList.Add(newClient);

            Boolean isConnected = true;

            /*******************************************************
             * Grabs the incoming buffer size to make the proper
             * byte array.  Then grabs the clients message from the
             * our getData method.  sendData will be used to deliver
             * the message to each client (theoretically).
             *******************************************************/
            while (isConnected == true)
            {
                try
                {
                    string message;
                    stream = newClient.GetStream();
                    int bufferSize = newClient.ReceiveBufferSize;
                    message = getData(stream, bufferSize);

                    // This is a string that may be sent from the client to let the server
                    // know that they are disconnecting so that the server can gracefully
                    // remove the client.
                    if(message != "43ijF#1jio34IO!")
                    {
                        sendData(stream, bufferSize, message);
                    }
                    else
                    {
                        isConnected = false;
                        clientList.Remove(newClient);
                        newClient.Close();
                        Console.WriteLine("Client at {0} has disconnected", connectingClient);
                        break;
                    }
                }
                catch (ObjectDisposedException e)
                {
                    Console.WriteLine("Error in handleClient: " + e);
                }
                catch (IOException e)
                {
                    Console.WriteLine("Error in handleClient: " + e);
                }
                catch (Exception catchAll)
                {
                    Console.WriteLine("Error in handleClient: " + catchAll);
                }
            }
        }
        private string getData(NetworkStream incoming, int bufferSize)
        {
            /*******************************************************
             * Creates a byte array to hold the income data, which
             * is then decoded back into a string for viewing
             * purposes in the console.
             *******************************************************/
            byte[] buffer = new byte[bufferSize];
            int dataTotal = incoming.Read(buffer, 0, bufferSize);
            string message = Encoding.ASCII.GetString(buffer, 0, dataTotal);
            Console.WriteLine("Message Recieved: " + message); // Debug
            return message;
        }
        private void sendData(NetworkStream outgoing, int bufferSize, string message)
        {
            /*******************************************************
             * Encodes string message into bytes, then sends out
             * the message to each person in the client list.
             *******************************************************/
            try
            {
                byte[] sendMessage = Encoding.ASCII.GetBytes(message);

                foreach(object obj in clientList)
                {
                    TcpClient sendToClient = (TcpClient)obj;
                    outgoing = sendToClient.GetStream();
                    outgoing.Write(sendMessage, 0, sendMessage.Length);
                    //Console.WriteLine("Message Recieved: " + message); // Debug
                }
            }
            catch(ObjectDisposedException e)
            {
                Console.WriteLine("Error in handleClient: " + e);
            }
            catch(Exception catchAll)
            {
                Console.WriteLine("Error occured in sendData: " + catchAll);
            }
        }
    }
}
