namespace BTVN1_Nhom6_NT106.Q12
{
    partial class Quenmatkhau
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
            TB_Username = new TextBox();
            LB_Username = new Label();
            BT_Xacthuc = new Button();
            TB_OTP = new TextBox();
            LB_OTP = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // TB_Username
            // 
            TB_Username.Location = new Point(345, 162);
            TB_Username.Name = "TB_Username";
            TB_Username.Size = new Size(257, 27);
            TB_Username.TabIndex = 11;
            // 
            // LB_Username
            // 
            LB_Username.AutoSize = true;
            LB_Username.Font = new Font("Segoe UI", 11F);
            LB_Username.Location = new Point(134, 162);
            LB_Username.Name = "LB_Username";
            LB_Username.Size = new Size(184, 25);
            LB_Username.TabIndex = 10;
            LB_Username.Text = "Nhập Email đăng ký:";
            // 
            // BT_Xacthuc
            // 
            BT_Xacthuc.Location = new Point(331, 265);
            BT_Xacthuc.Name = "BT_Xacthuc";
            BT_Xacthuc.Size = new Size(121, 39);
            BT_Xacthuc.TabIndex = 23;
            BT_Xacthuc.Text = "Xác thực";
            BT_Xacthuc.UseVisualStyleBackColor = true;
            BT_Xacthuc.Click += BT_Dangnhap_Click;
            // 
            // TB_OTP
            // 
            TB_OTP.Location = new Point(345, 217);
            TB_OTP.Name = "TB_OTP";
            TB_OTP.Size = new Size(121, 27);
            TB_OTP.TabIndex = 25;
            // 
            // LB_OTP
            // 
            LB_OTP.AutoSize = true;
            LB_OTP.Font = new Font("Segoe UI", 11F);
            LB_OTP.Location = new Point(171, 219);
            LB_OTP.Name = "LB_OTP";
            LB_OTP.Size = new Size(101, 25);
            LB_OTP.TabIndex = 24;
            LB_OTP.Text = "Nhập OTP:";
            // 
            // button1
            // 
            button1.Location = new Point(515, 212);
            button1.Name = "button1";
            button1.Size = new Size(87, 36);
            button1.TabIndex = 26;
            button1.Text = "Gửi lại";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Quenmatkhau
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(807, 440);
            Controls.Add(button1);
            Controls.Add(TB_OTP);
            Controls.Add(LB_OTP);
            Controls.Add(BT_Xacthuc);
            Controls.Add(TB_Username);
            Controls.Add(LB_Username);
            Name = "Quenmatkhau";
            Text = "Quenmatkhau";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TB_Username;
        private Label LB_Username;
        private Button BT_Xacthuc;
        private TextBox TB_OTP;
        private Label LB_OTP;
        private Button button1;
    }
}