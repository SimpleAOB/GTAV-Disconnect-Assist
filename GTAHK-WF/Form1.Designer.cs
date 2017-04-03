namespace GTAHK_WF
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
            this.components = new System.ComponentModel.Container();
            this.ReloadInterfaces = new System.Windows.Forms.Button();
            this.nconsole = new System.Windows.Forms.TextBox();
            this.hklbl = new System.Windows.Forms.Label();
            this.ReconnectTimer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.althk = new System.Windows.Forms.Button();
            this.CreateSoloWorker = new System.ComponentModel.BackgroundWorker();
            this.PSDCWorker = new System.ComponentModel.BackgroundWorker();
            this.sololbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ReloadInterfaces
            // 
            this.ReloadInterfaces.Location = new System.Drawing.Point(278, 226);
            this.ReloadInterfaces.Name = "ReloadInterfaces";
            this.ReloadInterfaces.Size = new System.Drawing.Size(105, 23);
            this.ReloadInterfaces.TabIndex = 0;
            this.ReloadInterfaces.Text = "Reload Interfaces";
            this.ReloadInterfaces.UseVisualStyleBackColor = true;
            this.ReloadInterfaces.Click += new System.EventHandler(this.ReloadInterfaces_Click);
            // 
            // nconsole
            // 
            this.nconsole.Location = new System.Drawing.Point(13, 12);
            this.nconsole.Multiline = true;
            this.nconsole.Name = "nconsole";
            this.nconsole.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.nconsole.Size = new System.Drawing.Size(370, 146);
            this.nconsole.TabIndex = 2;
            this.nconsole.WordWrap = false;
            // 
            // hklbl
            // 
            this.hklbl.AutoSize = true;
            this.hklbl.Location = new System.Drawing.Point(12, 161);
            this.hklbl.Name = "hklbl";
            this.hklbl.Size = new System.Drawing.Size(249, 13);
            this.hklbl.TabIndex = 3;
            this.hklbl.Text = "Current HotKey (10s Disconnect): CTRL+NumPad1";
            // 
            // ReconnectTimer
            // 
            this.ReconnectTimer.Interval = 10000;
            this.ReconnectTimer.Tick += new System.EventHandler(this.InterfaceReconnect);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label1.Location = new System.Drawing.Point(132, 236);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Made by Simple_AOB <3";
            // 
            // althk
            // 
            this.althk.Location = new System.Drawing.Point(13, 226);
            this.althk.Name = "althk";
            this.althk.Size = new System.Drawing.Size(103, 23);
            this.althk.TabIndex = 1;
            this.althk.Text = "Alternate Hotkey";
            this.althk.UseVisualStyleBackColor = true;
            this.althk.Click += new System.EventHandler(this.althk_Click);
            // 
            // CreateSoloWorker
            // 
            this.CreateSoloWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.CreateSoloWorker_DoWork);
            this.CreateSoloWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.InterfacesReconnected);
            // 
            // PSDCWorker
            // 
            this.PSDCWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.PSDCWorker_DoWork);
            this.PSDCWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.InterfacesReconnected);
            // 
            // sololbl
            // 
            this.sololbl.AutoSize = true;
            this.sololbl.Location = new System.Drawing.Point(12, 174);
            this.sololbl.Name = "sololbl";
            this.sololbl.Size = new System.Drawing.Size(260, 13);
            this.sololbl.TabIndex = 5;
            this.sololbl.Text = "Current HotKey (Solo Public Lobby): CTRL+NumPad1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 261);
            this.Controls.Add(this.sololbl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.hklbl);
            this.Controls.Add(this.nconsole);
            this.Controls.Add(this.althk);
            this.Controls.Add(this.ReloadInterfaces);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GTAV Interface Disconnector";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ReloadInterfaces;
        private System.Windows.Forms.TextBox nconsole;
        private System.Windows.Forms.Label hklbl;
        private System.Windows.Forms.Timer ReconnectTimer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button althk;
        private System.ComponentModel.BackgroundWorker CreateSoloWorker;
        private System.ComponentModel.BackgroundWorker PSDCWorker;
        private System.Windows.Forms.Label sololbl;
    }
}

