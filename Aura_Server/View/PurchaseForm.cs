using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Aura.Model;
using Aura_Server.Model;

namespace Aura_Server.View
{   
    public partial class PurchaseForm : Form
    {
        private Purchase purchase;

        public PurchaseForm(Purchase purchase)
        {
            InitializeComponent();
            this.purchase = purchase;
            LoadCatalogs();
            FillForm();
        }

        private void LoadCatalogs()
        {
            //заполнить справочники для выпадающих меню
            foreach (var item in Catalog.purchasesNames)
            {
                purchaseMethodID.Items.Add(item);
            }

            foreach (var item in Catalog.statusesNames)
            {
                statusID.Items.Add(item);
            }

            employeID.Items.Add("<не указано>");
            foreach (var item in Program.usersDataBase.GetAllUsers())
            {
                employeID.Items.Add(item.name);
            }

            foreach (var item in Catalog.organisationsNames)
            {
                organizationID.Items.Add(item);
            }

        }

        private void FillForm()
        {
            purchaseName.Text = purchase.purchaseName;
            purchaseMethodID.SelectedIndex = purchase.purchaseMethodID;
            purchacePrice.Text = purchase.purchacePrice.ToString("### ### ### ### ###.##");
            purchaseEisNum.Text = purchase.purchaseEisNum;
            SetDate(purchaseEisDate, purchase.purchaseEisDate);

            statusID.SelectedIndex = purchase.statusID;
            employeID.SelectedIndex = purchase.employeID;
            organizationID.SelectedIndex = purchase.organizationID;

            SetDate(bidsStartDate, purchase.bidsStartDate);
            SetDate(bidsEndDate, purchase.bidsEndDate);
            SetDate(bidsOpenDate, purchase.bidsOpenDate);
            SetDate(bidsFinishDate, purchase.bidsFinishDate);

            SetDate(bidsFirstPartDate, purchase.bidsFirstPartDate);
            SetDate(auctionDate, purchase.auctionDate);
            SetDate(bidsSecondPartDate, purchase.bidsSecondPartDate);

            SetDate(contractDatePlan, purchase.contractDatePlan);
            SetDate(contractDateLast, purchase.contractDateLast);
            SetDate(reestrDateLast, purchase.reestrDateLast);

            reestrNumber.Text = purchase.reestrNumber;
            contractPrice.Text = purchase.contractPrice.ToString("### ### ### ### ###.##");
            SetDate(contractDateReal, purchase.contractDateReal);

            comments.Text = purchase.comments;

        }

        private void SetDate(DateTimePicker picker, string date)
        {
            DateTime dateTime = Convert.ToDateTime(date);
            if (dateTime == DateTime.MinValue)
            {
                picker.Format = DateTimePickerFormat.Custom;
                picker.CustomFormat = "''";
            }

            else
            {
                picker.Format = DateTimePickerFormat.Short;
                picker.Value = dateTime;
            }
        }

    }
}
