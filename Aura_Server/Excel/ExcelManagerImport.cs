using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Aura.Model;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace Aura_Server.Excel
{
    class ExcelManagerImport
    {
        //класс предназначен для работы с данными из таблицы Excel
        DataFromExcel dataFromExcel;

        public ExcelManagerImport()
        {
            dataFromExcel = new DataFromExcel();
        }

        public List<Organisation> LoadOrganisationsFromFile(string fileName)
        {
            var data = dataFromExcel.LoadFromFile(fileName);

            foreach (var row in data)
            {
                try
                {
                    Purchase pur = new Purchase();

                    StringBuilder sb = new StringBuilder();
                    foreach (var s in row)
                    {
                        sb.Append(s);
                        sb.Append(" ");
                    }

                    MessageBox.Show(sb.ToString());
                    



                }

                catch(Exception ex)
                {

                }

            }

            return new List<Organisation>();

        }

    }
}
