namespace BTVN1_Nhom6_NT106.Q12
{
    partial class ThongTinNguoiDung
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblXinChao;
        private System.Windows.Forms.Label LB_Username;
        private System.Windows.Forms.TextBox txtTenDangNhap;
        private System.Windows.Forms.Label LB_Email;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label LB_MK;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.Button btnShowPass;
        private System.Windows.Forms.Label LB_SDT;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Label LB_GT;
        private System.Windows.Forms.TextBox txtGioiTinh;
        private System.Windows.Forms.Label LB_NS;
        private System.Windows.Forms.TextBox txtNgaySinh;
        private System.Windows.Forms.Label LB_DC;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Button btnDangXuat;

        /// <summary>
        /// Dọn tài nguyên
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            lblTitle = new Label();
            lblXinChao = new Label();
            LB_Username = new Label();
            txtTenDangNhap = new TextBox();
            LB_Email = new Label();
            txtEmail = new TextBox();
            LB_MK = new Label();
            txtMatKhau = new TextBox();
            btnShowPass = new Button();
            LB_SDT = new Label();
            txtSDT = new TextBox();
            LB_GT = new Label();
            txtGioiTinh = new TextBox();
            LB_NS = new Label();
            txtNgaySinh = new TextBox();
            LB_DC = new Label();
            txtDiaChi = new TextBox();
            btnDangXuat = new Button();
            pnlHeader.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.SteelBlue;
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(626, 60);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(123, 18);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(385, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "ỨNG DỤNG QUẢN LÝ NGƯỜI DÙNG";
            // 
            // lblXinChao
            // 
            lblXinChao.AutoSize = true;
            lblXinChao.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblXinChao.Location = new Point(30, 80);
            lblXinChao.Name = "lblXinChao";
            lblXinChao.Size = new Size(83, 23);
            lblXinChao.TabIndex = 1;
            lblXinChao.Text = "Xin chào,";
            // 
            // LB_Username
            // 
            LB_Username.AutoSize = true;
            LB_Username.Location = new Point(120, 143);
            LB_Username.Name = "LB_Username";
            LB_Username.Size = new Size(78, 20);
            LB_Username.TabIndex = 2;
            LB_Username.Text = "Username:";
            // 
            // txtTenDangNhap
            // 
            txtTenDangNhap.Location = new Point(240, 140);
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.Size = new Size(230, 27);
            txtTenDangNhap.TabIndex = 14;
            // 
            // LB_Email
            // 
            LB_Email.AutoSize = true;
            LB_Email.Location = new Point(120, 178);
            LB_Email.Name = "LB_Email";
            LB_Email.Size = new Size(49, 20);
            LB_Email.TabIndex = 13;
            LB_Email.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(240, 175);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(230, 27);
            txtEmail.TabIndex = 12;
            // 
            // LB_MK
            // 
            LB_MK.AutoSize = true;
            LB_MK.Location = new Point(120, 213);
            LB_MK.Name = "LB_MK";
            LB_MK.Size = new Size(73, 20);
            LB_MK.TabIndex = 11;
            LB_MK.Text = "Mật khẩu:";
            // 
            // txtMatKhau
            // 
            txtMatKhau.Location = new Point(240, 210);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.Size = new Size(230, 27);
            txtMatKhau.TabIndex = 10;
            txtMatKhau.UseSystemPasswordChar = true;
            // 
            // btnShowPass
            // 
            btnShowPass.Font = new Font("Segoe UI", 9F);
            btnShowPass.Location = new Point(475, 210);
            btnShowPass.Name = "btnShowPass";
            btnShowPass.Size = new Size(35, 27);
            btnShowPass.TabIndex = 9;
            btnShowPass.Text = "👁";
            btnShowPass.Click += btnShowPass_Click_1;
            // 
            // LB_SDT
            // 
            LB_SDT.AutoSize = true;
            LB_SDT.Location = new Point(120, 248);
            LB_SDT.Name = "LB_SDT";
            LB_SDT.Size = new Size(100, 20);
            LB_SDT.TabIndex = 8;
            LB_SDT.Text = "Số điện thoại:";
            // 
            // txtSDT
            // 
            txtSDT.Location = new Point(240, 245);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(230, 27);
            txtSDT.TabIndex = 7;
            // 
            // LB_GT
            // 
            LB_GT.AutoSize = true;
            LB_GT.Location = new Point(120, 283);
            LB_GT.Name = "LB_GT";
            LB_GT.Size = new Size(68, 20);
            LB_GT.TabIndex = 6;
            LB_GT.Text = "Giới tính:";
            // 
            // txtGioiTinh
            // 
            txtGioiTinh.Location = new Point(240, 280);
            txtGioiTinh.Name = "txtGioiTinh";
            txtGioiTinh.Size = new Size(230, 27);
            txtGioiTinh.TabIndex = 5;
            // 
            // LB_NS
            // 
            LB_NS.AutoSize = true;
            LB_NS.Location = new Point(120, 318);
            LB_NS.Name = "LB_NS";
            LB_NS.Size = new Size(77, 20);
            LB_NS.TabIndex = 4;
            LB_NS.Text = "Ngày sinh:";
            // 
            // txtNgaySinh
            // 
            txtNgaySinh.Location = new Point(240, 315);
            txtNgaySinh.Name = "txtNgaySinh";
            txtNgaySinh.Size = new Size(230, 27);
            txtNgaySinh.TabIndex = 3;
            // 
            // LB_DC
            // 
            LB_DC.AutoSize = true;
            LB_DC.Location = new Point(120, 353);
            LB_DC.Name = "LB_DC";
            LB_DC.Size = new Size(58, 20);
            LB_DC.TabIndex = 2;
            LB_DC.Text = "Địa chỉ:";
            // 
            // txtDiaChi
            // 
            txtDiaChi.Location = new Point(240, 350);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(230, 27);
            txtDiaChi.TabIndex = 1;
            // 
            // btnDangXuat
            // 
            btnDangXuat.BackColor = Color.Salmon;
            btnDangXuat.FlatStyle = FlatStyle.Flat;
            btnDangXuat.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDangXuat.ForeColor = Color.White;
            btnDangXuat.Location = new Point(240, 398);
            btnDangXuat.Name = "btnDangXuat";
            btnDangXuat.Size = new Size(150, 40);
            btnDangXuat.TabIndex = 0;
            btnDangXuat.Text = "🚪 Đăng xuất";
            btnDangXuat.UseVisualStyleBackColor = false;
            btnDangXuat.Click += btnDangXuat_Click_1;
            // 
            // ThongTinNguoiDung
            // 
            ClientSize = new Size(626, 504);
            Controls.Add(btnDangXuat);
            Controls.Add(txtDiaChi);
            Controls.Add(LB_DC);
            Controls.Add(txtNgaySinh);
            Controls.Add(LB_NS);
            Controls.Add(txtGioiTinh);
            Controls.Add(LB_GT);
            Controls.Add(txtSDT);
            Controls.Add(LB_SDT);
            Controls.Add(btnShowPass);
            Controls.Add(txtMatKhau);
            Controls.Add(LB_MK);
            Controls.Add(txtEmail);
            Controls.Add(LB_Email);
            Controls.Add(txtTenDangNhap);
            Controls.Add(LB_Username);
            Controls.Add(lblXinChao);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "ThongTinNguoiDung";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thông tin người dùng";
            Load += ThongTinNguoiDung_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion
    }
}
