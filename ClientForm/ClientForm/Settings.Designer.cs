namespace ClientForm
{
    partial class Settings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelUsernamePrompt = new System.Windows.Forms.Label();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelServerIPPrompt = new System.Windows.Forms.Label();
            this.textBoxServerIP = new System.Windows.Forms.TextBox();
            this.labelServerPortPrompt = new System.Windows.Forms.Label();
            this.textBoxServerPort = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelUsernamePrompt
            // 
            this.labelUsernamePrompt.AutoSize = true;
            this.labelUsernamePrompt.Location = new System.Drawing.Point(13, 13);
            this.labelUsernamePrompt.Name = "labelUsernamePrompt";
            this.labelUsernamePrompt.Size = new System.Drawing.Size(107, 13);
            this.labelUsernamePrompt.TabIndex = 0;
            this.labelUsernamePrompt.Text = "Enter your username:";
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(13, 30);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(238, 20);
            this.textBoxUsername.TabIndex = 1;
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(176, 146);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 4;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(255, 146);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelServerIPPrompt
            // 
            this.labelServerIPPrompt.AutoSize = true;
            this.labelServerIPPrompt.Location = new System.Drawing.Point(13, 53);
            this.labelServerIPPrompt.Name = "labelServerIPPrompt";
            this.labelServerIPPrompt.Size = new System.Drawing.Size(51, 13);
            this.labelServerIPPrompt.TabIndex = 4;
            this.labelServerIPPrompt.Text = "Server IP";
            // 
            // textBoxServerIP
            // 
            this.textBoxServerIP.Location = new System.Drawing.Point(13, 69);
            this.textBoxServerIP.Name = "textBoxServerIP";
            this.textBoxServerIP.Size = new System.Drawing.Size(140, 20);
            this.textBoxServerIP.TabIndex = 2;
            // 
            // labelServerPortPrompt
            // 
            this.labelServerPortPrompt.AutoSize = true;
            this.labelServerPortPrompt.Location = new System.Drawing.Point(13, 92);
            this.labelServerPortPrompt.Name = "labelServerPortPrompt";
            this.labelServerPortPrompt.Size = new System.Drawing.Size(60, 13);
            this.labelServerPortPrompt.TabIndex = 6;
            this.labelServerPortPrompt.Text = "Server Port";
            // 
            // textBoxServerPort
            // 
            this.textBoxServerPort.Location = new System.Drawing.Point(12, 108);
            this.textBoxServerPort.Name = "textBoxServerPort";
            this.textBoxServerPort.Size = new System.Drawing.Size(141, 20);
            this.textBoxServerPort.TabIndex = 3;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 181);
            this.Controls.Add(this.textBoxServerPort);
            this.Controls.Add(this.labelServerPortPrompt);
            this.Controls.Add(this.textBoxServerIP);
            this.Controls.Add(this.labelServerIPPrompt);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.textBoxUsername);
            this.Controls.Add(this.labelUsernamePrompt);
            this.Name = "Settings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelUsernamePrompt;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelServerIPPrompt;
        private System.Windows.Forms.TextBox textBoxServerIP;
        private System.Windows.Forms.Label labelServerPortPrompt;
        private System.Windows.Forms.TextBox textBoxServerPort;
    }
}