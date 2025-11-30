using System;
using System.Windows.Forms;

namespace project.Forms
{
    public class LoginForm : Form
    {
        private Label lblFirstName;
        private Label lblLastName;
        private Label lblEmail;

        private TextBox tbFirstName;
        private TextBox tbLastName;
        private TextBox tbEmail;

        private Button btnLogin;

        public LoginForm()
        {
            this.Text = "Форма логіну";
            this.ClientSize = new System.Drawing.Size(350, 150);

            int lblX = 20, tbX = 120, y = 20, dy = 30;

            lblFirstName = new Label { Text = "Ім'я:", Location = new System.Drawing.Point(lblX, y) };
            tbFirstName = new TextBox { Location = new System.Drawing.Point(tbX, y - 3), Size = new System.Drawing.Size(200, 23) };
            y += dy;

            lblLastName = new Label { Text = "Прізвище:", Location = new System.Drawing.Point(lblX, y) };
            tbLastName = new TextBox { Location = new System.Drawing.Point(tbX, y - 3), Size = new System.Drawing.Size(200, 23) };
            y += dy;

            lblEmail = new Label { Text = "Пошта:", Location = new System.Drawing.Point(lblX, y) };
            tbEmail = new TextBox { Location = new System.Drawing.Point(tbX, y - 3), Size = new System.Drawing.Size(200, 23) };
            y += dy + 10;

            btnLogin = new Button { Text = "Увійти", Location = new System.Drawing.Point(tbX, y), Size = new System.Drawing.Size(100, 30) };
            btnLogin.Click += BtnLogin_Click;

            this.Controls.Add(lblFirstName);
            this.Controls.Add(tbFirstName);
            this.Controls.Add(lblLastName);
            this.Controls.Add(tbLastName);
            this.Controls.Add(lblEmail);
            this.Controls.Add(tbEmail);
            this.Controls.Add(btnLogin);
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string firstName = tbFirstName.Text.Trim();
            string lastName = tbLastName.Text.Trim();
            string email = tbEmail.Text.Trim();

            if (firstName == "" || lastName == "" || email == "")
            {
                MessageBox.Show("Заповніть всі поля!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show($"Привіт, {firstName} {lastName}!\nВаша пошта: {email}", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK; 
            this.Close();
        }
    }
}

