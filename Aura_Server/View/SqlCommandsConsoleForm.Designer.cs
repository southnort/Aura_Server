namespace Aura_Server.View
{
    partial class SqlCommandsConsoleForm
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
            this.queryTextBox = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.requestButton = new System.Windows.Forms.Button();
            this.resultTextBox = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.clearFieldsButton = new System.Windows.Forms.Button();
            this.createBackUpDateBase = new System.Windows.Forms.Button();
            this.clearFormatting = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // queryTextBox
            // 
            this.queryTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.queryTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.queryTextBox.ForeColor = System.Drawing.Color.SpringGreen;
            this.queryTextBox.Location = new System.Drawing.Point(12, 29);
            this.queryTextBox.Name = "queryTextBox";
            this.queryTextBox.Size = new System.Drawing.Size(760, 139);
            this.queryTextBox.TabIndex = 0;
            this.queryTextBox.Text = "";
            this.queryTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.queryTextBox_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Lime;
            this.label1.Location = new System.Drawing.Point(9, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Введите сюда SQL запрос к БД";
            // 
            // requestButton
            // 
            this.requestButton.BackColor = System.Drawing.Color.Lime;
            this.requestButton.Location = new System.Drawing.Point(15, 403);
            this.requestButton.Name = "requestButton";
            this.requestButton.Size = new System.Drawing.Size(116, 31);
            this.requestButton.TabIndex = 2;
            this.requestButton.Text = "Отправить запроc";
            this.requestButton.UseVisualStyleBackColor = false;
            this.requestButton.Click += new System.EventHandler(this.requestButton_Click);
            // 
            // resultTextBox
            // 
            this.resultTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.resultTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.resultTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.resultTextBox.ForeColor = System.Drawing.Color.SpringGreen;
            this.resultTextBox.Location = new System.Drawing.Point(12, 187);
            this.resultTextBox.Name = "resultTextBox";
            this.resultTextBox.Size = new System.Drawing.Size(760, 210);
            this.resultTextBox.TabIndex = 3;
            this.resultTextBox.Text = "";
            this.resultTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SqlCommandsConsoleForm_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Lime;
            this.label2.Location = new System.Drawing.Point(12, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Результат запроса";
            // 
            // clearFieldsButton
            // 
            this.clearFieldsButton.BackColor = System.Drawing.Color.Orange;
            this.clearFieldsButton.Location = new System.Drawing.Point(137, 403);
            this.clearFieldsButton.Name = "clearFieldsButton";
            this.clearFieldsButton.Size = new System.Drawing.Size(134, 31);
            this.clearFieldsButton.TabIndex = 5;
            this.clearFieldsButton.Text = "Очистить поля";
            this.clearFieldsButton.UseVisualStyleBackColor = false;
            this.clearFieldsButton.Click += new System.EventHandler(this.clearFieldsButton_Click);
            // 
            // createBackUpDateBase
            // 
            this.createBackUpDateBase.BackColor = System.Drawing.Color.DarkTurquoise;
            this.createBackUpDateBase.Location = new System.Drawing.Point(638, 403);
            this.createBackUpDateBase.Name = "createBackUpDateBase";
            this.createBackUpDateBase.Size = new System.Drawing.Size(134, 31);
            this.createBackUpDateBase.TabIndex = 6;
            this.createBackUpDateBase.Text = "Сделать бэкап";
            this.createBackUpDateBase.UseVisualStyleBackColor = false;
            this.createBackUpDateBase.Click += new System.EventHandler(this.createBackUpDateBase_Click);
            // 
            // clearFormatting
            // 
            this.clearFormatting.BackColor = System.Drawing.Color.Moccasin;
            this.clearFormatting.Location = new System.Drawing.Point(277, 403);
            this.clearFormatting.Name = "clearFormatting";
            this.clearFormatting.Size = new System.Drawing.Size(155, 31);
            this.clearFormatting.TabIndex = 7;
            this.clearFormatting.Text = "Сбросить форматирование";
            this.clearFormatting.UseVisualStyleBackColor = false;
            this.clearFormatting.Click += new System.EventHandler(this.clearFormatting_Click);
            // 
            // SqlCommandsConsoleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(784, 446);
            this.Controls.Add(this.clearFormatting);
            this.Controls.Add(this.createBackUpDateBase);
            this.Controls.Add(this.clearFieldsButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.resultTextBox);
            this.Controls.Add(this.requestButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.queryTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SqlCommandsConsoleForm";
            this.Text = "SqlCommandsConsoleForm";
            this.Load += new System.EventHandler(this.SqlCommandsConsoleForm_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SqlCommandsConsoleForm_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox queryTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button requestButton;
        private System.Windows.Forms.RichTextBox resultTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button clearFieldsButton;
        private System.Windows.Forms.Button createBackUpDateBase;
        private System.Windows.Forms.Button clearFormatting;
    }
}