using System;
using System.Net;
using System.Windows.Forms;

namespace ClientForm
{
    public partial class Settings : Form
    {
        /*******************************************************
        * Gets some possible presets from Form1
        *******************************************************/
        private void Settings_Load(object sender, EventArgs e)
        {
            textBoxUsername.Text = Form1.username;
            textBoxServerPort.Text = Form1.port.ToString();
            textBoxServerIP.Text = Form1.serverIP.ToString();
        }

        public Settings()
        {
            InitializeComponent();
        }

        /*******************************************************
        * Overrides the escape key to close the settings window.
        *******************************************************/
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Escape))
            {
                buttonCancel_Click(null, null);
                return true;
            }
            else if (keyData == (Keys.Enter))
            {
                buttonOk_Click(null, null);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        /*******************************************************
        * Close without saving any information
        *******************************************************/
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /*******************************************************
        * Save information that the user filled in on Form1
        *******************************************************/
        private void buttonOk_Click(object sender, EventArgs e)
        {
            try
            {
                Form1.username = textBoxUsername.Text;
                Form1.serverIP = IPAddress.Parse(textBoxServerIP.Text);
                this.Close();
            } catch (Exception)
            {
                MessageBox.Show("Please enter in a server IP or click cancel.", "Error: Missing Information");
            }
        }

    }
}
