using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Aura_Server.Model;
using Aura.Model;

namespace Aura_Server.View
{
    public partial class OpenUserForm : Form
    {
        //форма представляет конкретного одиночного юзера
        //через эту форму можно добавлять юзеров в БД и редактировать их

        public User returnUser;

        public OpenUserForm(User user)
        {
            InitializeComponent();

            CheckUserBeforeFill(user);
            
        }

        private void CheckUserBeforeFill(User user)
        {
            //проверка, создается новый пользователь или редактируется уже имеющийся
            if (user.name == string.Empty || user.name == "" || user.name == null)
            {
                FillWindowNewUser();
                returnUser = new User();
            }
            else
            {
                FillWindowExistingUser(user);
                returnUser = user;
            }
        }

        private void FillWindowNewUser()
        {
            Text = "Добавление нового пользователя";
            accessLevelNumericUpDown.Value = 1;

        }

        private void FillWindowExistingUser(User user)
        {
            Text = "Редактирование - " + user.name;
            nameTextBox.Text = user.name;
            nameTextBox.Enabled = false;
            loginTextBox.Text = user.login;
            loginTextBox.Enabled = false;
            passwordTextBox.Text = user.password;
            accessLevelNumericUpDown.Value = user.roleID;

        }



        private string CheckUserBeforeSave()
        {
            //проверка заполнения полей
            //если всё хорошо - возвращается пустая строка
            StringBuilder sb = new StringBuilder();

            if (nameTextBox.Text == string.Empty)
                sb.Append("Необходимо указать отображаемое имя");

            if (loginTextBox.Text == string.Empty)
                sb.Append("\nНеобходимо указать логин");

            if (passwordTextBox.Text == string.Empty)
                sb.Append("\nНеобходимо указать пароль");

            return sb.ToString();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string checkResult = CheckUserBeforeSave();

            if (checkResult == string.Empty)
            {
                returnUser.name = nameTextBox.Text;
                returnUser.login = loginTextBox.Text;
                returnUser.password = passwordTextBox.Text;
                returnUser.roleID = (int)accessLevelNumericUpDown.Value;

                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void OpenUserForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }
    }
}
