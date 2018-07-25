namespace Aura_Server.View
{
    partial class LoginWindow
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
            this.loginTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.resultTextLabel = new System.Windows.Forms.Label();
            this.showUsersButton = new System.Windows.Forms.Button();
            this.tryLoginButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // loginTextBox
            // 
            this.loginTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loginTextBox.Location = new System.Drawing.Point(241, 100);
            this.loginTextBox.Name = "loginTextBox";
            this.loginTextBox.Size = new System.Drawing.Size(348, 26);
            this.loginTextBox.TabIndex = 0;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.passwordTextBox.Location = new System.Drawing.Point(241, 132);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(348, 26);
            this.passwordTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(180, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Логин";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(168, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Пароль";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(281, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(259, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "\"Аура-Сервер\" приветствует Вас";
            // 
            // resultTextLabel
            // 
            this.resultTextLabel.AutoSize = true;
            this.resultTextLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.resultTextLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.resultTextLabel.Location = new System.Drawing.Point(328, 236);
            this.resultTextLabel.Name = "resultTextLabel";
            this.resultTextLabel.Size = new System.Drawing.Size(117, 17);
            this.resultTextLabel.TabIndex = 6;
            this.resultTextLabel.Text = "connectionResult";
            // 
            // showUsersButton
            // 
            this.showUsersButton.Location = new System.Drawing.Point(640, 85);
            this.showUsersButton.Name = "showUsersButton";
            this.showUsersButton.Size = new System.Drawing.Size(103, 73);
            this.showUsersButton.TabIndex = 7;
            this.showUsersButton.Text = "Пользователи системы";
            this.showUsersButton.UseVisualStyleBackColor = true;
            this.showUsersButton.Click += new System.EventHandler(this.showUsersButton_Click);
            // 
            // tryLoginButton
            // 
            this.tryLoginButton.Location = new System.Drawing.Point(331, 190);
            this.tryLoginButton.Name = "tryLoginButton";
            this.tryLoginButton.Size = new System.Drawing.Size(146, 43);
            this.tryLoginButton.TabIndex = 8;
            this.tryLoginButton.Text = "Вход";
            this.tryLoginButton.UseVisualStyleBackColor = true;
            this.tryLoginButton.Click += new System.EventHandler(this.tryLoginButton_Click);
            // 
            // LoginWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 309);
            this.Controls.Add(this.tryLoginButton);
            this.Controls.Add(this.showUsersButton);
            this.Controls.Add(this.resultTextLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.loginTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "LoginWindow";
            this.Text = "Аутентификация";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox loginTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label resultTextLabel;
        private System.Windows.Forms.Button showUsersButton;
        private System.Windows.Forms.Button tryLoginButton;
    }
}