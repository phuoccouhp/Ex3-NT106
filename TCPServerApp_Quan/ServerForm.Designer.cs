using System;
using System.Windows.Forms;
using System.Drawing;

namespace TcpServerApp
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
            this.txtLog = new System.Windows.Forms.TextBox();
            this.btn_start = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtLog
            // 
            this.txtLog.BackColor = SystemColors.Desktop;
            this.txtLog.Location = new Point(27, 12);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new Size(601, 439);
            this.txtLog.TabIndex = 0;
            // 
            // btn_start
            // 
            this.btn_start.BackColor = SystemColors.MenuHighlight;
            this.btn_start.Font = new Font("Segoe UI", 15F);
            this.btn_start.Location = new Point(672, 191);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new Size(194, 82);
            this.btn_start.TabIndex = 1;
            this.btn_start.Text = "Start";
            this.btn_start.UseVisualStyleBackColor = false;
            this.btn_start.Click += new EventHandler(this.btn_start_Click);
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new Size(948, 476);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.txtLog);
            this.Name = "ServerForm";
            this.Text = "ServerForm";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button btn_start;
    }
}