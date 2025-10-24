using System;
using System.Windows.Forms;

namespace UserManagementClient
{
    public class RegisterForm : Form
    {
        private TextBox txtUsername, txtPassword, txtConfirm, txtEmail, txtFullName;
        private DateTimePicker dtpBirthday;
        private Button btnRegister, btnBack;

        public RegisterForm()
        {
            this.Text = "Đăng ký";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ClientSize = new System.Drawing.Size(420, 300);

            int labelX = 20, inputX = 150, y = 25, step = 35;

            Controls.Add(new Label() { Text = "Username", Left = labelX, Top = y, AutoSize = true });
            txtUsername = new TextBox() { Left = inputX, Top = y, Width = 230 }; y += step;

            Controls.Add(new Label() { Text = "Password", Left = labelX, Top = y, AutoSize = true });
            txtPassword = new TextBox() { Left = inputX, Top = y, Width = 230, UseSystemPasswordChar = true }; y += step;

            Controls.Add(new Label() { Text = "Confirm", Left = labelX, Top = y, AutoSize = true });
            txtConfirm = new TextBox() { Left = inputX, Top = y, Width = 230, UseSystemPasswordChar = true }; y += step;

            Controls.Add(new Label() { Text = "Email", Left = labelX, Top = y, AutoSize = true });
            txtEmail = new TextBox() { Left = inputX, Top = y, Width = 230 }; y += step;

            Controls.Add(new Label() { Text = "Full Name", Left = labelX, Top = y, AutoSize = true });
            txtFullName = new TextBox() { Left = inputX, Top = y, Width = 230 }; y += step;

            Controls.Add(new Label() { Text = "Birthday", Left = labelX, Top = y, AutoSize = true });
            dtpBirthday = new DateTimePicker()
            {
                Left = inputX,
                Top = y,
                Width = 230,
                Format = DateTimePickerFormat.Short,
                ShowCheckBox = true
            };
            y += step + 10;

            btnRegister = new Button() { Text = "Đăng ký", Left = inputX, Top = y, Width = 100 };
            btnBack = new Button() { Text = "Quay lại", Left = inputX + 110, Top = y, Width = 100 };

            btnRegister.Click += BtnRegister_Click;
            btnBack.Click += BtnBack_Click;

            Controls.AddRange(new Control[]
            {
                txtUsername, txtPassword, txtConfirm, txtEmail, txtFullName,
                dtpBirthday, btnRegister, btnBack
            });
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đăng ký thành công!");
            LoginForm login = new LoginForm();
            login.Show();
            this.Hide();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();
            this.Hide();
        }
    }
}
