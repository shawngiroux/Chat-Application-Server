using System;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

/// <summary>
/// Name: Shawn Giroux
/// Date: January 11th, 2016
/// Summary: A windows form chat client to connect a chat server.
/// </summary>

namespace ClientForm
{
    public partial class Form1 : Form
    {
        /*******************************************************
        * Declaring variables for later use.
        *******************************************************/

        /* Server info */
        public static int port = 26900;
        public static IPAddress serverIP;
        //public static IPAddress serverIP = IPAddress.Parse("10.0.0.245"); // For LAN connection
        //IPAddress serverIP = IPAddress.Parse("24.62.170.60"); // For external connections

        /* Used for handling server */
        TcpClient client;

        /* Reads and writes messages to server */
        NetworkStream stream;

        /* Used to set textbox on separate thread */
        delegate void SetTextCallback(string text);

        /* Lets our program know that it is still connected */
        Boolean isConnected = false;

        /* Stores username */
        public static string username;

        public Form1()
        {
            InitializeComponent();
        }

        /*******************************************************
        * Overrides the enter key to send messages so the user
        * no longer has to click the "send" button.
        *******************************************************/
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == (Keys.Enter))
            {
                buttonSend_Click(null,null);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        /*******************************************************
        * When the user selects "connect" from the menustrip,
        * the program connects to the pre-determined server
        * address.  A thread is then start to handle all
        * incoming responses.  Menustsrip dialogs trade enabled
        * status for aethetics.
        *******************************************************/
        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (username != null)
            {
                try {
                    settingsToolStripMenuItem.Enabled = false;
                    client = new TcpClient(serverIP.ToString(), port);
                    LabelConnectionStatus.Text = "Connection Status: Connected";
                    stream = client.GetStream();
                    isConnected = true;
                    connectToolStripMenuItem.Enabled = false;
                    disconnectToolStripMenuItem.Enabled = true;
                    Thread t = new Thread(recieveMessages);
                    t.Start();
                    textBoxRecieveMessage.AppendText("::Connected to Server::\r\n");
                }
                catch (SocketException)
                {
                    MessageBox.Show("Error: Time out", "Session has timed out");
                }
            }
            else
            {
                string message = "      Please set a username and server IP under Options -> Settings";
                string caption = "Error: No Username";
                MessageBox.Show(message, caption);
            }
        }

        /*******************************************************
        * Selecting "disconnect" from the menustrip will close
        * connections to the server. "isConnected" will become
        * false to gracefully end other parts of the program.
        * Menustrip dialogs trade enabled status for
        * aesthetics. "43ijF#1jio34IO!" is sent to let the
        * server know that the user is disconnecting. 
        *******************************************************/
        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] goodbye = Encoding.ASCII.GetBytes(username + " has left the room.");
                stream.Write(goodbye, 0, goodbye.Length);
                stream.Flush();
                settingsToolStripMenuItem.Enabled = true;
                byte[] disconnect = Encoding.ASCII.GetBytes("43ijF#1jio34IO!");
                stream.Write(disconnect, 0, disconnect.Length);
                stream.Flush();
                client.Close();
                stream.Close();
                textBoxRecieveMessage.AppendText("::Disconnected::\r\n");
                isConnected = false;
                LabelConnectionStatus.Text = "Connection Status: Offline";
                connectToolStripMenuItem.Enabled = true;
                disconnectToolStripMenuItem.Enabled = false;
            }
            catch (System.IO.IOException)
            {
                // No connection to server.
                // This try/catch may be better on being added to when the program is shutting down.
                // If the user is trying to shut down the server, they wouldn't need to see this error
                // but this error may be useful if it happens while the server is running and the user
                // only wanted to disconnect.
            }
        }

        /*******************************************************
        * When user clicks the send button, message from the
        * adjacent dialogue box is encoded and sent off to the
        * server.
        *******************************************************/
        private void buttonSend_Click(object sender, EventArgs e)
        {
            if (isConnected == true)
            {
                if (textBoxSendMessage.Text != null)
                {
                    try
                    {
                        string messageString = "<" + username + "> " + textBoxSendMessage.Text;
                        byte[] message = Encoding.ASCII.GetBytes(messageString);
                        stream.Write(message, 0, message.Length);
                        stream.Flush();
                        textBoxSendMessage.Text = null;
                    }
                    catch (System.IO.IOException)
                    {
                        MessageBox.Show("Error: Connection Lost", "Connect was lost from the server");
                        client.Close();
                        stream.Close();
                        textBoxRecieveMessage.AppendText("::Disconnected::\r\n");
                        isConnected = false;
                        LabelConnectionStatus.Text = "Connection Status: Offline";
                        connectToolStripMenuItem.Enabled = true;
                        disconnectToolStripMenuItem.Enabled = false;
                    }
                }
            }
            else
            {
                string message = "You are not connected to the server!";
                string caption = "Error: Can't send message";
                MessageBox.Show(message, caption);
            }
        }

        /*******************************************************
        * recieveMessages is run on a separate thread to make
        * sure that the client stays up to date with all
        * incoming messages.
        * WARNING: When program is nearing completion, perhaps
        * add a Thread.Sleep to low CPU usage.
        *******************************************************/
        private void recieveMessages()
        {
            try {
                while (isConnected == true)
                {
                    byte[] bytes = new byte[client.ReceiveBufferSize];
                    int dataTotal = stream.Read(bytes, 0, bytes.Length);
                    string message = Encoding.ASCII.GetString(bytes, 0, dataTotal);
                    displayMessage(message);
                    //MessageBox.Show(message); // Debug dialog box
                }
            }
            catch (System.IO.IOException)
            {
                // This catch stops program from breaking when not disconnected
                // Perhaps print to an error log
            }
        }

        /*******************************************************
        * This method will set the message in the textbox.
        * Invoke is used since the process is happening on a
        * different thread an what textBoxRecieveMessage was
        * created on. I think (not sure) that it waits until
        * a moment is avaible on the main thread to update it.
        *******************************************************/
        private void displayMessage(string message)
        {
            try
            {
                if (this.textBoxRecieveMessage.InvokeRequired)
                {
                    SetTextCallback d = new SetTextCallback(displayMessage);
                    this.Invoke(d, new object[] { message });
                }
                else
                {
                    textBoxRecieveMessage.AppendText(message + "\r\n");
                }
            }
            catch (ObjectDisposedException)
            {
                // This catch stops program from breaking when not disconnected
                // Perhaps print to an error log
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(disconnectToolStripMenuItem.Enabled == true)
            {
                disconnectToolStripMenuItem.PerformClick();
            }
            Application.Exit();
        }


        /*******************************************************
        * If the form is closed, the program will gracefully
        * disconnect from the server.
        *******************************************************/
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (disconnectToolStripMenuItem.Enabled == true)
            {
                disconnectToolStripMenuItem.PerformClick();
            }
            Application.Exit();
        }
    }
}
