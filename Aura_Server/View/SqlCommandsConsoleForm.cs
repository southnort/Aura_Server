﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aura_Server.Controller;

namespace Aura_Server.View
{
    public partial class SqlCommandsConsoleForm : Form
    {
        private DataBaseManager dataBase = Program.dataBase;

        public SqlCommandsConsoleForm()
        {
            InitializeComponent();
        }


        private void SendRequest()
        {
            try
            {
                FillResultWindow(ConvertResponceToText(GetData(queryTextBox.Text)));
            }
            catch (Exception ex)
            {
                FillResultWindow(ex.Message);
            }
        }

        private DataTable GetData(string sqlCommand)
        {
            var table = dataBase.GetTable(sqlCommand);
            return table;
        }

        private string ConvertResponceToText(DataTable table)
        {
            if (table.Rows.Count < 1)
                return "Empty table";
            else
            {

                StringBuilder sb = new StringBuilder();
                foreach (DataRow row in table.Rows)
                {
                    foreach (var cell in row.ItemArray)
                    {
                        sb.Append(cell.ToString() + "  ");
                    }
                    sb.Append("\n\n");
                }

                return sb.ToString();
            }
        }

        private void FillResultWindow(string text)
        {
            resultTextBox.Clear();
            resultTextBox.Text = text;
        }
       


        private void SqlCommandsConsoleForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendRequest();
            }

        }

        private void requestButton_Click(object sender, EventArgs e)
        {
            SendRequest();
        }

        private void clearFieldsButton_Click(object sender, EventArgs e)
        {
            queryTextBox.Clear();
            resultTextBox.Clear();
        }

        private void SqlCommandsConsoleForm_Load(object sender, EventArgs e)
        {

        }
    }
}
