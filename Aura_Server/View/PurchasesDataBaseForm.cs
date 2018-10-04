using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Aura_Server.Controller;
using Aura.Model;
using Aura_Server.View;

namespace Aura_Server.View
{
    public partial class PurchasesDataBaseForm : Form
    {
        private PurchasesTableAdapter adapter;

        public PurchasesDataBaseForm(PurchasesTableAdapter adapter)
        {
            InitializeComponent();
            this.adapter = adapter;
            ReloadTable(adapter.GetAllPurchasesInTable());

        }

        private void ReloadTable(DataTable table)
        {
            ClearTable();
            FillTable(table);
        }

        private void FillTable(DataTable table)
        {
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    var row = table.Rows[i];
                    object[] newRow = new object[]
                    {
                        row[0],
                        row[3],
                        row[4],
                        row[5],
                        row[8],
                        row[1],
                        row[22],

                    };

                    dataGridView1.Rows.Add(newRow);

                }
            }
        }

        private void ClearTable()
        {
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows.Clear();
            }
        }


        private void ShowPurchase(Purchase purchase)
        {
            //открыть форму просмотра закупки


            PurchaseForm form = new PurchaseForm(purchase);
            var result = form.ShowDialog();

            //if (result == DialogResult.OK)
            //{
            //    adapter.AddUser(form.returnUser);
            //    ReloadTable(adapter.GetUsersInTable());

            //}

        }





        private void button1_Click(object sender, EventArgs e)
        {
            ShowPurchase(new Purchase());
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dg = (DataGridView)sender;
            int purchaseID = (int)(long)dg.Rows[e.RowIndex].Cells[0].Value;

            Purchase purchase = adapter.GetPurchase(purchaseID);
            ShowPurchase(purchase);
            
        }
    }
}
