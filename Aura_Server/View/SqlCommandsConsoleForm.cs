using Aura_Server.Controller;
using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Aura_Server.View
{
    public partial class SqlCommandsConsoleForm : Form
    {
        private DataBaseManager dataBase = Program.dataBase;
        private Font formFont;
        private Color formTextColor;
        private bool showWindow = false;

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
            if (sqlCommand.ToLower().Contains(" from logs") || sqlCommand.ToLower().Contains("update logs "))
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
            queryTextBox.SelectionStart = 0;
            queryTextBox.SelectionLength = queryTextBox.TextLength;
            queryTextBox.SelectionColor = formTextColor;
        }

        
        private void SetActive(bool value)
        {
            //свернуть / развернуть из трея
            ShowInTaskbar = value;
            Visible = value;
            notifyIcon1.Visible = true;
            showWindow = value;

            if (value)
                WindowState = FormWindowState.Normal;
           
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
            SetActive(false);
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

        private void clearFormatting_Click(object sender, EventArgs e)
        {
            LoadFont();
        }

        private void SqlCommandsConsoleForm_Deactivate(object sender, EventArgs e)
        {
            SetActive(false);         
               
            
        }
        
        private void NotifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //  SetActive(!showWindow);
            SetActive(true);
        }
    }

}
