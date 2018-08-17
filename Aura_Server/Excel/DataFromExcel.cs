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
    class DataFromExcel
    {
        //класс предназначен для обработки одной таблицы из файла Excel
        public DataFromExcel()
        {
            dbCells = new List<List<string>>();
        }


        List<List<string>> dbCells;    //двумерный список, формируемый из таблицы
        public List<List<string>> LoadFromFile(string filePath)
        {            
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                using (SpreadsheetDocument doc = SpreadsheetDocument.Open(fs, false))
                {
                    WorkbookPart workbookPart = doc.WorkbookPart;
                    SharedStringTablePart sstpart = workbookPart.GetPartsOfType<SharedStringTablePart>().First();
                    SharedStringTable sst = sstpart.SharedStringTable;


                    WorksheetPart worksheetPart = workbookPart.WorksheetParts.First();
                    Worksheet sheet = worksheetPart.Worksheet;


                    var cells = sheet.Descendants<Cell>();
                    var rows = sheet.Descendants<Row>();
                    var columns = sheet.Descendants<Column>();


                    foreach (Row row in rows)
                    {
                        List<string> rowString = new List<string>();
                        foreach (Cell c in row.Elements<Cell>())
                        {
                            if ((c.DataType != null) && (c.DataType == CellValues.SharedString))
                            {
                                int ssid = int.Parse(c.CellValue.Text);
                                string str = sst.ChildElements[ssid].InnerText;
                                rowString.Add(str);
                            }

                            else if (c.CellValue != null)
                            {
                                Console.WriteLine("Cell contents: {0}", c.CellValue.Text);
                            }
                        }

                        dbCells.Add(rowString);
                    }


                }


            }

            return dbCells;
        }



    }
}
