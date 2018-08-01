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
    public partial class UsersDataBaseForm : Form
    {
        private UsersTableAdapter adapter;

        public UsersDataBaseForm(UsersTableAdapter adapter)
        {
            InitializeComponent();            
            this.adapter = adapter;
            ReloadTable(adapter.GetUsersInTable());
            
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
                        row[1],
                        row[2],
                        row[4],

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

        
        private void ShowUser(User user)
        {
            //открыть форму просмотра юзера
            OpenUserForm form = new OpenUserForm(user);
            var result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                adapter.AddUser(form.returnUser);
                ReloadTable(adapter.GetUsersInTable());

            }

        }





        private void button1_Click(object sender, EventArgs e)
        {
            ShowUser(new User());
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dg = (DataGridView)sender;
            int userID = (int)(long)dg.Rows[e.RowIndex].Cells[0].Value;
            User user = adapter.GetUser(userID);

            ShowUser(user);
        }
    }
}
