using System;
using System.IO;
using System.Linq;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;


namespace Aura_Server.Excel
{
    public class ExcelReader
    {
        //класс предназначен для чтения данных из таблицы Excel
        public List<List<string>> GetFromFile(string filePath)
        {
            List<List<string>> tableCells = new List<List<string>>();
            if (File.Exists(filePath))
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (SpreadsheetDocument doc = SpreadsheetDocument.Open(fs, false))
                    {
                        WorkbookPart workbookPart = doc.WorkbookPart;
                        SharedStringTablePart sstPart = workbookPart.GetPartsOfType<SharedStringTablePart>().First();
                        SharedStringTable sst = sstPart.SharedStringTable;

                        WorksheetPart worksheetPart = workbookPart.WorksheetParts.Last();
                        Worksheet sheet = worksheetPart.Worksheet;

                        var cells = sheet.Descendants<Cell>();
                        var rows = sheet.Descendants<Row>();


                        foreach (Row row in rows)
                        {
                            List<string> rowList = new List<string>();
                            foreach (Cell cell in row.Elements<Cell>())
                            {
                                if ((cell.DataType != null) && (cell.DataType == CellValues.SharedString))
                                {
                                    int ssid = int.Parse(cell.CellValue.Text);
                                    string str = sst.ChildElements[ssid].InnerText;
                                    rowList.Add(str);
                                }
                                else if (cell.CellValue != null)
                                {

                                }

                            }

                            tableCells.Add(rowList);

                        }



                    }
                }

                return tableCells;

            }

            else
            {
                throw new Exception("Файл не найден " + filePath);
            }

        }

    }

}
