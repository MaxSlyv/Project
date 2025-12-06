using System;
using System.Drawing;
using System.Windows.Forms;

namespace project.Forms
{
    public class LoginForm : Form
    {
        private Label lblFirstName;
        private Label lblLastName;
        private Label lblEmail;
        private Label lblPassword;

        private TextBox tbFirstName;
        private TextBox tbLastName;
        private TextBox tbEmail;
        private TextBox tbPassword;
        private Button btnLogin;

        private const string AllowedFirstName = "Максим";
        private const string AllowedLastName = "Сливар";
        private const string AllowedEmail = "mksslivar@gmail.com";
        private const string AllowedPassword = "12345678";

        public LoginForm()
        {
            this.Text = "Форма логіну";
            this.ClientSize = new System.Drawing.Size(600, 300);
            this.BackgroundImage = Image.FromFile(@"D:\4 курс\Курсовий\background_login.jpg"); 
            this.BackgroundImageLayout = ImageLayout.Stretch;


            int startX = 20, startY = 30;
            int spacingX = 200, spacingY = 30;

            lblFirstName = new Label { Text = "Ім'я:", Location = new System.Drawing.Point(startX, startY) };
            tbFirstName = new TextBox { Location = new System.Drawing.Point(startX + 100, startY - 3), Size = new System.Drawing.Size(180, 25) };


            lblLastName = new Label { Text = "Прізвище:", Location = new System.Drawing.Point(startX + spacingX, startY + spacingY + 10) };
            tbLastName = new TextBox { Location = new System.Drawing.Point(startX + spacingX + 100, startY + spacingY + 7), Size = new System.Drawing.Size(180, 25) };


            lblEmail = new Label { Text = "Пошта:", Location = new System.Drawing.Point(startX, startY + spacingY * 2 + 20) };
            tbEmail = new TextBox { Location = new System.Drawing.Point(startX + 100, startY + spacingY * 2 + 17), Size = new System.Drawing.Size(180, 25) };

            lblPassword = new Label { Text = "Пароль:", Location = new System.Drawing.Point(startX + spacingX, startY + spacingY * 3 + 30) };
            tbPassword = new TextBox { Location = new System.Drawing.Point(startX + spacingX + 100, startY + spacingY * 3 + 27), Size = new System.Drawing.Size(180, 25), UseSystemPasswordChar = true };


            btnLogin = new Button { Text = "Увійти", Location = new System.Drawing.Point(startX + 180, startY + spacingY * 6), Size = new System.Drawing.Size(120, 35) };
            btnLogin.Click += BtnLogin_Click;

            this.Controls.Add(lblFirstName);
            this.Controls.Add(tbFirstName);
            this.Controls.Add(lblLastName);
            this.Controls.Add(tbLastName);
            this.Controls.Add(lblEmail);
            this.Controls.Add(tbEmail);
            this.Controls.Add(lblPassword);
            this.Controls.Add(tbPassword);
            this.Controls.Add(btnLogin);
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string firstName = tbFirstName.Text.Trim();
            string lastName = tbLastName.Text.Trim();
            string email = tbEmail.Text.Trim();
            string password = tbPassword.Text;

            if (firstName == "" || lastName == "" || email == "" || password == "")
            {
                MessageBox.Show("Заповніть всі поля!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //перевірка
            if (firstName == AllowedFirstName &&
                lastName == AllowedLastName &&
                email == AllowedEmail &&
                password == AllowedPassword)
            {
                MessageBox.Show($"Привіт, {firstName} {lastName}!\nВаша пошта: {email}", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Невірні дані. Доступ заборонено!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
