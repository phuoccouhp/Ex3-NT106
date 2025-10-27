namespace TCPServer
{
    partial class ServerForm
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
            btnStart = new Button();
            lblStatus = new Label();
            btnStop = new Button();
            txtLog = new RichTextBox();
            SuspendLayout();
            // 
            // btnStart
            // 
            btnStart.Location = new Point(74, 215);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(121, 39);
            btnStart.TabIndex = 22;
            btnStart.Text = "Start Server";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click_1;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 11F);
            lblStatus.Location = new Point(74, 139);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(133, 25);
            lblStatus.TabIndex = 20;
            lblStatus.Text = "Status : Offline";
            // 
            // btnStop
            // 
            btnStop.Location = new Point(74, 298);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(121, 39);
            btnStop.TabIndex = 23;
            btnStop.Text = "Stop Server";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click_1;
            // 
            // txtLog
            // 
            txtLog.Dock = DockStyle.Right;
            txtLog.Location = new Point(246, 0);
            txtLog.Name = "txtLog";
            txtLog.ReadOnly = true;
            txtLog.Size = new Size(554, 450);
            txtLog.TabIndex = 24;
            txtLog.Text = "";
            // 
            // ServerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtLog);
            Controls.Add(btnStop);
            Controls.Add(btnStart);
            Controls.Add(lblStatus);
            Name = "ServerForm";
            Text = "ServerForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnStart;
        private Label lblStatus;
        private Button btnStop;
        private RichTextBox txtLog;
    }
}