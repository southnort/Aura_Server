namespace Aura_Server.View
{
    partial class PurchaseForm
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
            this.employeID = new System.Windows.Forms.ComboBox();
            this.organizationID = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.purchaseMethodID = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.purchaseName = new System.Windows.Forms.TextBox();
            this.statusID = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.purchacePrice = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.purchaseEisNum = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.purchaseEisDate = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.bidsStartDate = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.bidsEndDate = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.bidsOpenDate = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.bidsFirstPartDate = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.bidsSecondPartDate = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.auctionDate = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            this.bidsFinishDate = new System.Windows.Forms.DateTimePicker();
            this.label16 = new System.Windows.Forms.Label();
            this.contractDatePlan = new System.Windows.Forms.DateTimePicker();
            this.label17 = new System.Windows.Forms.Label();
            this.contractDateLast = new System.Windows.Forms.DateTimePicker();
            this.label18 = new System.Windows.Forms.Label();
            this.contractDateReal = new System.Windows.Forms.DateTimePicker();
            this.label19 = new System.Windows.Forms.Label();
            this.reestrDateLast = new System.Windows.Forms.DateTimePicker();
            this.reestrNumber = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.contractPrice = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.comments = new System.Windows.Forms.RichTextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.dateTimePicker14 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker15 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker16 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker18 = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(513, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ответственный";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // employeID
            // 
            this.employeID.FormattingEnabled = true;
            this.employeID.Location = new System.Drawing.Point(605, 42);
            this.employeID.Name = "employeID";
            this.employeID.Size = new System.Drawing.Size(176, 21);
            this.employeID.TabIndex = 1;
            // 
            // organizationID
            // 
            this.organizationID.FormattingEnabled = true;
            this.organizationID.Location = new System.Drawing.Point(534, 69);
            this.organizationID.Name = "organizationID";
            this.organizationID.Size = new System.Drawing.Size(248, 21);
            this.organizationID.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(404, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Организация-заказчик";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // purchaseMethodID
            // 
            this.purchaseMethodID.FormattingEnabled = true;
            this.purchaseMethodID.Location = new System.Drawing.Point(145, 43);
            this.purchaseMethodID.Name = "purchaseMethodID";
            this.purchaseMethodID.Size = new System.Drawing.Size(248, 21);
            this.purchaseMethodID.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Способ определения";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Наименование закупки";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // purchaseName
            // 
            this.purchaseName.Location = new System.Drawing.Point(145, 17);
            this.purchaseName.Name = "purchaseName";
            this.purchaseName.Size = new System.Drawing.Size(248, 20);
            this.purchaseName.TabIndex = 7;
            // 
            // statusID
            // 
            this.statusID.FormattingEnabled = true;
            this.statusID.Location = new System.Drawing.Point(605, 15);
            this.statusID.Name = "statusID";
            this.statusID.Size = new System.Drawing.Size(176, 21);
            this.statusID.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(558, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Статус";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // purchacePrice
            // 
            this.purchacePrice.Location = new System.Drawing.Point(145, 70);
            this.purchacePrice.Name = "purchacePrice";
            this.purchacePrice.Size = new System.Drawing.Size(248, 20);
            this.purchacePrice.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(54, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Сумма закупки";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // purchaseEisNum
            // 
            this.purchaseEisNum.Location = new System.Drawing.Point(145, 96);
            this.purchaseEisNum.Name = "purchaseEisNum";
            this.purchaseEisNum.Size = new System.Drawing.Size(158, 20);
            this.purchaseEisNum.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(38, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Номер извещения";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // purchaseEisDate
            // 
            this.purchaseEisDate.CustomFormat = "\'\'";
            this.purchaseEisDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.purchaseEisDate.Location = new System.Drawing.Point(145, 122);
            this.purchaseEisDate.Name = "purchaseEisDate";
            this.purchaseEisDate.Size = new System.Drawing.Size(158, 20);
            this.purchaseEisDate.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 125);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(129, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Дата публикации в ЕИС";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(97, 179);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(121, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Начало подачи заявок";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bidsStartDate
            // 
            this.bidsStartDate.CustomFormat = "\'\'";
            this.bidsStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.bidsStartDate.Location = new System.Drawing.Point(224, 179);
            this.bidsStartDate.Name = "bidsStartDate";
            this.bidsStartDate.Size = new System.Drawing.Size(158, 20);
            this.bidsStartDate.TabIndex = 16;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(79, 205);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(139, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Окончание подачи заявок";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bidsEndDate
            // 
            this.bidsEndDate.CustomFormat = "\'\'";
            this.bidsEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.bidsEndDate.Location = new System.Drawing.Point(224, 205);
            this.bidsEndDate.Name = "bidsEndDate";
            this.bidsEndDate.Size = new System.Drawing.Size(158, 20);
            this.bidsEndDate.TabIndex = 18;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(77, 231);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(141, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "Дата вскрытия конвертов";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bidsOpenDate
            // 
            this.bidsOpenDate.CustomFormat = "\'\'";
            this.bidsOpenDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.bidsOpenDate.Location = new System.Drawing.Point(224, 231);
            this.bidsOpenDate.Name = "bidsOpenDate";
            this.bidsOpenDate.Size = new System.Drawing.Size(158, 20);
            this.bidsOpenDate.TabIndex = 20;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(406, 179);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(158, 13);
            this.label12.TabIndex = 23;
            this.label12.Text = "Рассмотрение первых частей";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bidsFirstPartDate
            // 
            this.bidsFirstPartDate.CustomFormat = "\'\'";
            this.bidsFirstPartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.bidsFirstPartDate.Location = new System.Drawing.Point(570, 179);
            this.bidsFirstPartDate.Name = "bidsFirstPartDate";
            this.bidsFirstPartDate.Size = new System.Drawing.Size(158, 20);
            this.bidsFirstPartDate.TabIndex = 22;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(406, 231);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(157, 13);
            this.label13.TabIndex = 25;
            this.label13.Text = "Рассмотрение вторых частей";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bidsSecondPartDate
            // 
            this.bidsSecondPartDate.CustomFormat = "\'\'";
            this.bidsSecondPartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.bidsSecondPartDate.Location = new System.Drawing.Point(570, 231);
            this.bidsSecondPartDate.Name = "bidsSecondPartDate";
            this.bidsSecondPartDate.Size = new System.Drawing.Size(158, 20);
            this.bidsSecondPartDate.TabIndex = 24;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(418, 205);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(146, 13);
            this.label14.TabIndex = 27;
            this.label14.Text = "Дата проведения аукциона";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // auctionDate
            // 
            this.auctionDate.CustomFormat = "\'\'";
            this.auctionDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.auctionDate.Location = new System.Drawing.Point(570, 205);
            this.auctionDate.Name = "auctionDate";
            this.auctionDate.Size = new System.Drawing.Size(158, 20);
            this.auctionDate.TabIndex = 26;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(85, 257);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(133, 13);
            this.label15.TabIndex = 29;
            this.label15.Text = "Дата подведения итогов";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bidsFinishDate
            // 
            this.bidsFinishDate.CustomFormat = "\'\'";
            this.bidsFinishDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.bidsFinishDate.Location = new System.Drawing.Point(224, 257);
            this.bidsFinishDate.Name = "bidsFinishDate";
            this.bidsFinishDate.Size = new System.Drawing.Size(158, 20);
            this.bidsFinishDate.TabIndex = 28;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(33, 330);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(220, 13);
            this.label16.TabIndex = 31;
            this.label16.Text = "Планируемая дата подписания контракта";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // contractDatePlan
            // 
            this.contractDatePlan.CustomFormat = "\'\'";
            this.contractDatePlan.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.contractDatePlan.Location = new System.Drawing.Point(259, 330);
            this.contractDatePlan.Name = "contractDatePlan";
            this.contractDatePlan.Size = new System.Drawing.Size(158, 20);
            this.contractDatePlan.TabIndex = 30;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(59, 356);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(194, 13);
            this.label17.TabIndex = 33;
            this.label17.Text = "Крайняя дата подписания контракта";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // contractDateLast
            // 
            this.contractDateLast.CustomFormat = "\'\'";
            this.contractDateLast.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.contractDateLast.Location = new System.Drawing.Point(259, 356);
            this.contractDateLast.Name = "contractDateLast";
            this.contractDateLast.Size = new System.Drawing.Size(158, 20);
            this.contractDateLast.TabIndex = 32;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(372, 436);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(151, 13);
            this.label18.TabIndex = 35;
            this.label18.Text = "Дата подписания контракта";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // contractDateReal
            // 
            this.contractDateReal.CustomFormat = "\'\'";
            this.contractDateReal.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.contractDateReal.Location = new System.Drawing.Point(529, 436);
            this.contractDateReal.Name = "contractDateReal";
            this.contractDateReal.Size = new System.Drawing.Size(158, 20);
            this.contractDateReal.TabIndex = 34;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(446, 330);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(157, 26);
            this.label19.TabIndex = 37;
            this.label19.Text = "Крайняя дата для \r\nвнесения контракта в реестр";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // reestrDateLast
            // 
            this.reestrDateLast.CustomFormat = "\'\'";
            this.reestrDateLast.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.reestrDateLast.Location = new System.Drawing.Point(609, 330);
            this.reestrDateLast.Name = "reestrDateLast";
            this.reestrDateLast.Size = new System.Drawing.Size(158, 20);
            this.reestrDateLast.TabIndex = 36;
            // 
            // reestrNumber
            // 
            this.reestrNumber.Location = new System.Drawing.Point(197, 436);
            this.reestrNumber.Name = "reestrNumber";
            this.reestrNumber.Size = new System.Drawing.Size(158, 20);
            this.reestrNumber.TabIndex = 39;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(32, 439);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(159, 13);
            this.label20.TabIndex = 38;
            this.label20.Text = "Реестровый номер контракта";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // contractPrice
            // 
            this.contractPrice.Location = new System.Drawing.Point(197, 462);
            this.contractPrice.Name = "contractPrice";
            this.contractPrice.Size = new System.Drawing.Size(158, 20);
            this.contractPrice.TabIndex = 41;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(20, 462);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(171, 13);
            this.label21.TabIndex = 40;
            this.label21.Text = "Сумма заключенного контракта";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comments
            // 
            this.comments.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.comments.Location = new System.Drawing.Point(12, 556);
            this.comments.Name = "comments";
            this.comments.Size = new System.Drawing.Size(773, 172);
            this.comments.TabIndex = 42;
            this.comments.Text = "";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(9, 540);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(80, 13);
            this.label22.TabIndex = 43;
            this.label22.Text = "Комментарии:";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dateTimePicker14
            // 
            this.dateTimePicker14.CustomFormat = "\'\'";
            this.dateTimePicker14.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker14.Location = new System.Drawing.Point(224, 205);
            this.dateTimePicker14.Name = "dateTimePicker14";
            this.dateTimePicker14.Size = new System.Drawing.Size(158, 20);
            this.dateTimePicker14.TabIndex = 16;
            // 
            // dateTimePicker15
            // 
            this.dateTimePicker15.CustomFormat = "\'\'";
            this.dateTimePicker15.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker15.Location = new System.Drawing.Point(224, 231);
            this.dateTimePicker15.Name = "dateTimePicker15";
            this.dateTimePicker15.Size = new System.Drawing.Size(158, 20);
            this.dateTimePicker15.TabIndex = 18;
            // 
            // dateTimePicker16
            // 
            this.dateTimePicker16.CustomFormat = "\'\'";
            this.dateTimePicker16.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker16.Location = new System.Drawing.Point(224, 257);
            this.dateTimePicker16.Name = "dateTimePicker16";
            this.dateTimePicker16.Size = new System.Drawing.Size(158, 20);
            this.dateTimePicker16.TabIndex = 20;
            // 
            // dateTimePicker18
            // 
            this.dateTimePicker18.CustomFormat = "\'\'";
            this.dateTimePicker18.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker18.Location = new System.Drawing.Point(259, 356);
            this.dateTimePicker18.Name = "dateTimePicker18";
            this.dateTimePicker18.Size = new System.Drawing.Size(158, 20);
            this.dateTimePicker18.TabIndex = 30;
            // 
            // PurchaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 791);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.comments);
            this.Controls.Add(this.contractPrice);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.reestrNumber);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.reestrDateLast);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.contractDateReal);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.contractDateLast);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.dateTimePicker18);
            this.Controls.Add(this.contractDatePlan);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.bidsFinishDate);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.auctionDate);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.bidsSecondPartDate);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.bidsFirstPartDate);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.dateTimePicker16);
            this.Controls.Add(this.bidsOpenDate);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dateTimePicker15);
            this.Controls.Add(this.bidsEndDate);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dateTimePicker14);
            this.Controls.Add(this.bidsStartDate);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.purchaseEisDate);
            this.Controls.Add(this.purchaseEisNum);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.purchacePrice);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.statusID);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.purchaseName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.purchaseMethodID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.organizationID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.employeID);
            this.Controls.Add(this.label1);
            this.Name = "PurchaseForm";
            this.Text = "PurchaseForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox employeID;
        private System.Windows.Forms.ComboBox organizationID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox purchaseMethodID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox purchaseName;
        private System.Windows.Forms.ComboBox statusID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox purchacePrice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox purchaseEisNum;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker purchaseEisDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker bidsStartDate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker bidsEndDate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker bidsOpenDate;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker bidsFirstPartDate;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker bidsSecondPartDate;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker auctionDate;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker bidsFinishDate;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DateTimePicker contractDatePlan;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DateTimePicker contractDateLast;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DateTimePicker contractDateReal;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.DateTimePicker reestrDateLast;
        private System.Windows.Forms.TextBox reestrNumber;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox contractPrice;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.RichTextBox comments;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.DateTimePicker dateTimePicker14;
        private System.Windows.Forms.DateTimePicker dateTimePicker15;
        private System.Windows.Forms.DateTimePicker dateTimePicker16;
        private System.Windows.Forms.DateTimePicker dateTimePicker18;
    }
}