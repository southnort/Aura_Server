namespace Aura_Server.View
{
    partial class PurchasesCalendarForm
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
            this.upperPanel = new System.Windows.Forms.Panel();
            this.yearComboBox = new System.Windows.Forms.ComboBox();
            this.nextMonthButton = new System.Windows.Forms.Button();
            this.prevMonthButton = new System.Windows.Forms.Button();
            this.monthComboBox = new System.Windows.Forms.ComboBox();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.lowerPanel = new System.Windows.Forms.Panel();
            this.upperPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // upperPanel
            // 
            this.upperPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.upperPanel.BackColor = System.Drawing.SystemColors.Control;
            this.upperPanel.Controls.Add(this.yearComboBox);
            this.upperPanel.Controls.Add(this.nextMonthButton);
            this.upperPanel.Controls.Add(this.prevMonthButton);
            this.upperPanel.Controls.Add(this.monthComboBox);
            this.upperPanel.Location = new System.Drawing.Point(12, 12);
            this.upperPanel.Name = "upperPanel";
            this.upperPanel.Size = new System.Drawing.Size(1214, 74);
            this.upperPanel.TabIndex = 0;
            // 
            // yearComboBox
            // 
            this.yearComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yearComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.yearComboBox.FormattingEnabled = true;
            this.yearComboBox.Items.AddRange(new object[] {
            "2016",
            "2017",
            "2018",
            "2019",
            "2020",
            "2021",
            "2022"});
            this.yearComboBox.Location = new System.Drawing.Point(662, 14);
            this.yearComboBox.Name = "yearComboBox";
            this.yearComboBox.Size = new System.Drawing.Size(94, 39);
            this.yearComboBox.TabIndex = 3;
            this.yearComboBox.SelectedIndexChanged += new System.EventHandler(this.yearComboBox_SelectedIndexChanged);
            // 
            // nextMonthButton
            // 
            this.nextMonthButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nextMonthButton.Location = new System.Drawing.Point(762, 16);
            this.nextMonthButton.Name = "nextMonthButton";
            this.nextMonthButton.Size = new System.Drawing.Size(66, 39);
            this.nextMonthButton.TabIndex = 2;
            this.nextMonthButton.Text = ">";
            this.nextMonthButton.UseVisualStyleBackColor = true;
            this.nextMonthButton.Click += new System.EventHandler(this.nextMonthButton_Click);
            // 
            // prevMonthButton
            // 
            this.prevMonthButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.prevMonthButton.Location = new System.Drawing.Point(328, 14);
            this.prevMonthButton.Name = "prevMonthButton";
            this.prevMonthButton.Size = new System.Drawing.Size(66, 39);
            this.prevMonthButton.TabIndex = 1;
            this.prevMonthButton.Text = "<";
            this.prevMonthButton.UseVisualStyleBackColor = true;
            this.prevMonthButton.Click += new System.EventHandler(this.prevMonthButton_Click);
            // 
            // monthComboBox
            // 
            this.monthComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.monthComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.monthComboBox.FormattingEnabled = true;
            this.monthComboBox.Items.AddRange(new object[] {
            "Январь",
            "Февраль",
            "Март",
            "Апрель",
            "Май",
            "Июнь",
            "Июль",
            "Август",
            "Сентябрь",
            "Октябрь",
            "Ноябрь",
            "Декабрь"});
            this.monthComboBox.Location = new System.Drawing.Point(400, 14);
            this.monthComboBox.Name = "monthComboBox";
            this.monthComboBox.Size = new System.Drawing.Size(256, 39);
            this.monthComboBox.TabIndex = 0;
            this.monthComboBox.SelectedIndexChanged += new System.EventHandler(this.monthComboBox_SelectedIndexChanged);
            // 
            // mainPanel
            // 
            this.mainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainPanel.AutoScroll = true;
            this.mainPanel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.mainPanel.Location = new System.Drawing.Point(12, 92);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1214, 351);
            this.mainPanel.TabIndex = 1;
            // 
            // lowerPanel
            // 
            this.lowerPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lowerPanel.BackColor = System.Drawing.SystemColors.Control;
            this.lowerPanel.Location = new System.Drawing.Point(12, 449);
            this.lowerPanel.Name = "lowerPanel";
            this.lowerPanel.Size = new System.Drawing.Size(1214, 63);
            this.lowerPanel.TabIndex = 2;
            // 
            // PurchasesCalendarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1238, 524);
            this.Controls.Add(this.lowerPanel);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.upperPanel);
            this.Name = "PurchasesCalendarForm";
            this.Text = "PurchasesCalendarForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.upperPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel upperPanel;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel lowerPanel;
        private System.Windows.Forms.ComboBox yearComboBox;
        private System.Windows.Forms.Button nextMonthButton;
        private System.Windows.Forms.Button prevMonthButton;
        private System.Windows.Forms.ComboBox monthComboBox;
    }
}