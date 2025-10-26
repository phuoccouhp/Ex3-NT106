namespace BTVN1_Nhom6_NT106.Q12
{
    partial class MatKhauMoi
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
            LB_MKM = new Label();
            BT_Xacthuc = new Button();
            TB_MK = new TextBox();
            LB_MK = new Label();
            TB_MKM = new TextBox();
            LB_User = new Label();
            TB_User = new TextBox();
            SuspendLayout();
            // 
            // LB_MKM
            // 
            LB_MKM.AutoSize = true;
            LB_MKM.Font = new Font("Segoe UI", 11F);
            LB_MKM.Location = new Point(107, 206);
            LB_MKM.Name = "LB_MKM";
            LB_MKM.Size = new Size(207, 25);
            LB_MKM.TabIndex = 28;
            LB_MKM.Text = "Nhập lại mật khẩu mới:";
            // 
            // BT_Xacthuc
            // 
            BT_Xacthuc.Location = new Point(326, 259);
            BT_Xacthuc.Name = "BT_Xacthuc";
            BT_Xacthuc.Size = new Size(121, 39);
            BT_Xacthuc.TabIndex = 27;
            BT_Xacthuc.Text = "Đổi mật khẩu";
            BT_Xacthuc.UseVisualStyleBackColor = true;
            BT_Xacthuc.Click += BT_Xacthuc_Click;
            // 
            // TB_MK
            // 
            TB_MK.Location = new Point(347, 152);
            TB_MK.Name = "TB_MK";
            TB_MK.Size = new Size(257, 27);
            TB_MK.TabIndex = 26;
            // 
            // LB_MK
            // 
            LB_MK.AutoSize = true;
            LB_MK.Font = new Font("Segoe UI", 11F);
            LB_MK.Location = new Point(132, 152);
            LB_MK.Name = "LB_MK";
            LB_MK.Size = new Size(182, 25);
            LB_MK.TabIndex = 25;
            LB_MK.Text = "Nhập mật khẩu mới:";
            // 
            // TB_MKM
            // 
            TB_MKM.Location = new Point(347, 207);
            TB_MKM.Name = "TB_MKM";
            TB_MKM.Size = new Size(257, 27);
            TB_MKM.TabIndex = 29;
            // 
            // LB_User
            // 
            LB_User.AutoSize = true;
            LB_User.Font = new Font("Segoe UI", 11F);
            LB_User.Location = new Point(107, 106);
            LB_User.Name = "LB_User";
            LB_User.Size = new Size(205, 25);
            LB_User.TabIndex = 30;
            LB_User.Text = "Nhập Username/Email:";
            // 
            // TB_User
            // 
            TB_User.Location = new Point(347, 106);
            TB_User.Name = "TB_User";
            TB_User.Size = new Size(257, 27);
            TB_User.TabIndex = 31;
            // 
            // MatKhauMoi
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(TB_User);
            Controls.Add(LB_User);
            Controls.Add(TB_MKM);
            Controls.Add(LB_MKM);
            Controls.Add(BT_Xacthuc);
            Controls.Add(TB_MK);
            Controls.Add(LB_MK);
            Name = "MatKhauMoi";
            Text = "MatKhauMoi";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LB_MKM;
        private Button BT_Xacthuc;
        private TextBox TB_MK;
        private Label LB_MK;
        private TextBox TB_MKM;
        private Label LB_User;
        private TextBox TB_User;
    }
}