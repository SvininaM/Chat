namespace Client
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtChat = new System.Windows.Forms.TextBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.btnUserName = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.Color.MintCream;
            this.btnConnect.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnConnect.FlatAppearance.BorderSize = 0;
            this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnConnect.Location = new System.Drawing.Point(11, 12);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(95, 20);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Подключить";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(112, 38);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(210, 20);
            this.txtUserName.TabIndex = 1;
            // 
            // txtChat
            // 
            this.txtChat.BackColor = System.Drawing.Color.White;
            this.txtChat.Location = new System.Drawing.Point(11, 64);
            this.txtChat.Multiline = true;
            this.txtChat.Name = "txtChat";
            this.txtChat.ReadOnly = true;
            this.txtChat.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtChat.Size = new System.Drawing.Size(311, 356);
            this.txtChat.TabIndex = 2;
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(11, 426);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(276, 20);
            this.txtMessage.TabIndex = 3;
            // 
            // btnSend
            // 
            this.btnSend.FlatAppearance.BorderSize = 0;
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.Image = ((System.Drawing.Image)(resources.GetObject("btnSend.Image")));
            this.btnSend.Location = new System.Drawing.Point(289, 423);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(30, 25);
            this.btnSend.TabIndex = 4;
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtHost
            // 
            this.txtHost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHost.Location = new System.Drawing.Point(112, 11);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(209, 20);
            this.txtHost.TabIndex = 5;
            this.txtHost.Text = "LAPTOP-A8CMBCCM";
            this.txtHost.TextChanged += new System.EventHandler(this.txtHost_TextChanged);
            // 
            // btnUserName
            // 
            this.btnUserName.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnUserName.FlatAppearance.BorderSize = 0;
            this.btnUserName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUserName.Location = new System.Drawing.Point(11, 38);
            this.btnUserName.Name = "btnUserName";
            this.btnUserName.Size = new System.Drawing.Size(95, 20);
            this.btnUserName.TabIndex = 6;
            this.btnUserName.Text = "Сменить имя";
            this.btnUserName.UseVisualStyleBackColor = true;
            this.btnUserName.Visible = false;
            this.btnUserName.Click += new System.EventHandler(this.btnUserName_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(335, 458);
            this.Controls.Add(this.btnUserName);
            this.Controls.Add(this.txtHost);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.txtChat);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.btnConnect);
            this.Name = "Form1";
            this.Text = "Общий чат";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtChat;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtHost;
        private System.Windows.Forms.Button btnUserName;
    }
}