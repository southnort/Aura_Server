using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ClosedXML.Excel;

namespace Aura_Server.Excel
{
    public class ExcelWriter
    {
        public void ExportToFile(DataSet dataSet, string filePath)
        {
            var wb = new XLWorkbook();
            wb.Worksheets.Add(dataSet);

            wb.SaveAs(filePath);


        }

    }
}
