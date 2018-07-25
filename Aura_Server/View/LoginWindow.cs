using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Aura_Server.Controller;

namespace Aura_Server.View
{
    public partial class LoginWindow : Form
    {
        private UsersTableAdapter usersDataBase;

        public LoginWindow(UsersTableAdapter dataBase)
        {
            InitializeComponent();
            usersDataBase = dataBase;

            
        }

        private void showUsersButton_Click(object sender, EventArgs e)
        {
            UsersDataBaseForm usersForm = new UsersDataBaseForm(usersDataBase);
            usersForm.Show();
        }

        private void tryLoginButton_Click(object sender, EventArgs e)
        {
            if (loginTextBox.Text.Length > 0 && passwordTextBox.Text.Length > 0)
            {
                if (usersDataBase.CheckLoginAndPassword(loginTextBox.Text, passwordTextBox.Text))
                {
                    //если аутентификация пройдена
                    resultTextLabel.Text = "Аутентификация пройдена";
                    resultTextLabel.ForeColor = Color.Green;


                }

                else
                {
                    //если аутентификация не пройдена
                    resultTextLabel.Text = "Неправильный логин или пароль";
                    resultTextLabel.ForeColor = Color.Red;

                }
            }

        }
    }
}
