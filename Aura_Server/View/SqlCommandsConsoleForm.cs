using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Aura_Server.Controller;

namespace Aura_Server.View
{
    public partial class SqlCommandsConsoleForm : Form
    {
        private DataBaseManager dataBase = Program.dataBase;
        private Font formFont;
        private Color formTextColor;

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
            if (sqlCommand.ToLower().Contains(" from logs"))
            {
                var table = LogManager.Instance.GetTable(sqlCommand);
                return table;
            }

            else
            {
                var table = dataBase.GetTable(sqlCommand);
                return table;
            }
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

        private void SaveFont()
        {
            formTextColor = queryTextBox.ForeColor;
            formFont = queryTextBox.Font;
        }

        private void LoadFont()
        {
            queryTextBox.ForeColor = formTextColor;
            resultTextBox.ForeColor = formTextColor;
            queryTextBox.Font = formFont;
            resultTextBox.Font = formFont;
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
            SaveFont();
        }

        private void createBackUpDateBase_Click(object sender, EventArgs e)
        {
            try
            {
                Program.CreateBackup();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERROR");

            }

        }
        
        private void queryTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendRequest();
            }
        }

        private void queryTextBox_TextChanged_1(object sender, EventArgs e)
        {
            LoadFont();
        }
    }
}
