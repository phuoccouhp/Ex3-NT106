namespace BTVN1_Nhom6_NT106.Q12
{
    partial class Dangnhap
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
            TB_MK = new TextBox();
            LB_MK = new Label();
            TB_Username = new TextBox();
            LB_Username = new Label();
            LB_LinkForget = new LinkLabel();
            LB_Quen = new Label();
            BT_Dangnhap = new Button();
            Link_DK = new LinkLabel();
            SuspendLayout();
            // 
            // TB_MK
            // 
            TB_MK.Location = new Point(261, 125);
            TB_MK.Name = "TB_MK";
            TB_MK.Size = new Size(267, 27);
            TB_MK.TabIndex = 11;
            // 
            // LB_MK
            // 
            LB_MK.AutoSize = true;
            LB_MK.Font = new Font("Segoe UI", 11F);
            LB_MK.Location = new Point(108, 124);
            LB_MK.Name = "LB_MK";
            LB_MK.Size = new Size(91, 25);
            LB_MK.TabIndex = 10;
            LB_MK.Text = "Mật khẩu";
            // 
            // TB_Username
            // 
            TB_Username.Location = new Point(261, 80);
            TB_Username.Name = "TB_Username";
            TB_Username.Size = new Size(267, 27);
            TB_Username.TabIndex = 9;
            // 
            // LB_Username
            // 
            LB_Username.AutoSize = true;
            LB_Username.Font = new Font("Segoe UI", 11F);
            LB_Username.Location = new Point(79, 82);
            LB_Username.Name = "LB_Username";
            LB_Username.Size = new Size(150, 25);
            LB_Username.TabIndex = 8;
            LB_Username.Text = "Username/Email";
            // 
            // LB_LinkForget
            // 
            LB_LinkForget.AutoSize = true;
            LB_LinkForget.Location = new Point(412, 155);
            LB_LinkForget.Name = "LB_LinkForget";
            LB_LinkForget.Size = new Size(116, 20);
            LB_LinkForget.TabIndex = 24;
            LB_LinkForget.TabStop = true;
            LB_LinkForget.Text = "Quên mật khẩu?";
            LB_LinkForget.LinkClicked += LB_LinkForget_LinkClicked;
            // 
            // LB_Quen
            // 
            LB_Quen.AutoSize = true;
            LB_Quen.Font = new Font("Segoe UI", 9F);
            LB_Quen.Location = new Point(278, 230);
            LB_Quen.Name = "LB_Quen";
            LB_Quen.Size = new Size(154, 20);
            LB_Quen.TabIndex = 23;
            LB_Quen.Text = "nếu chưa có tài khoản";
            // 
            // BT_Dangnhap
            // 
            BT_Dangnhap.Location = new Point(261, 179);
            BT_Dangnhap.Name = "BT_Dangnhap";
            BT_Dangnhap.Size = new Size(121, 39);
            BT_Dangnhap.TabIndex = 22;
            BT_Dangnhap.Text = "Đăng nhập";
            BT_Dangnhap.UseVisualStyleBackColor = true;
            BT_Dangnhap.Click += BT_Dangnhap_Click;
            // 
            // Link_DK
            // 
            Link_DK.AutoSize = true;
            Link_DK.Location = new Point(218, 230);
            Link_DK.Name = "Link_DK";
            Link_DK.Size = new Size(63, 20);
            Link_DK.TabIndex = 25;
            Link_DK.TabStop = true;
            Link_DK.Text = "Đăng ký";
            Link_DK.LinkClicked += linkLabel1_LinkClicked;
            // 
            // Dangnhap
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(657, 277);
            Controls.Add(Link_DK);
            Controls.Add(LB_LinkForget);
            Controls.Add(LB_Quen);
            Controls.Add(BT_Dangnhap);
            Controls.Add(TB_MK);
            Controls.Add(LB_MK);
            Controls.Add(TB_Username);
            Controls.Add(LB_Username);
            Name = "Dangnhap";
            Text = "Dangnhap";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TB_MK;
        private Label LB_MK;
        private TextBox TB_Username;
        private Label LB_Username;
        private LinkLabel LB_LinkForget;
        private Label LB_Quen;
        private Button BT_Dangnhap;
        private LinkLabel Link_DK;
    }
}