namespace Aura_Server.View
{
    partial class OpenUserForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.loginTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.accessLevelNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.accessLevelNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(27, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Логин для входа в систему";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(152, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Пароль";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(74, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Отображаемое имя";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(217, 51);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(331, 20);
            this.nameTextBox.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(91, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Уровень доступа";
            // 
            // loginTextBox
            // 
            this.loginTextBox.Location = new System.Drawing.Point(217, 79);
            this.loginTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.loginTextBox.Name = "loginTextBox";
            this.loginTextBox.Size = new System.Drawing.Size(331, 20);
            this.loginTextBox.TabIndex = 5;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(217, 109);
            this.passwordTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(331, 20);
            this.passwordTextBox.TabIndex = 6;
            // 
            // accessLevelNumericUpDown
            // 
            this.accessLevelNumericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.accessLevelNumericUpDown.Location = new System.Drawing.Point(217, 161);
            this.accessLevelNumericUpDown.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.accessLevelNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.accessLevelNumericUpDown.Name = "accessLevelNumericUpDown";
            this.accessLevelNumericUpDown.Size = new System.Drawing.Size(120, 23);
            this.accessLevelNumericUpDown.TabIndex = 7;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Enabled = false;
            this.richTextBox1.Location = new System.Drawing.Point(94, 190);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(243, 86);
            this.richTextBox1.TabIndex = 8;
            this.richTextBox1.Text = "-1: Заблокированный пользователь\n 0: Права администратора\n 1: Стандартные права п" +
    "ользователя\n\nИспользоване других цифр может вызвать ошибки";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(155, 315);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(167, 54);
            this.saveButton.TabIndex = 9;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(347, 315);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(167, 54);
            this.closeButton.TabIndex = 10;
            this.closeButton.Text = "Отмена";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // OpenUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 416);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.accessLevelNumericUpDown);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.loginTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "OpenUserForm";
            this.Text = "Text";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OpenUserForm_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.accessLevelNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox loginTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.NumericUpDown accessLevelNumericUpDown;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button closeButton;
    }
}