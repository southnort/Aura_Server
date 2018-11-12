using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;


namespace Aura_Server.Excel
{
    /// <summary>
    /// класс предназначен для чтения данных из таблицы Excel
    /// </summary>
    public class ExcelReader
    {
        public List<List<string>> GetFromFile(string filePath)
        {
            List<List<string>> tableCells = new List<List<string>>();
            if (File.Exists(filePath))
            {
                using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
                {
                    IExcelDataReader excelReader = ExcelReaderFactory.CreateReader(stream);
                    DataSet result = excelReader.AsDataSet();
                    var table = result.Tables[0];

                    foreach (DataRow row in table.Rows)
                    {
                        List<string> rowString = new List<string>();

                        for (int i = 0; i < 10; i++)
                        {
                            try
                            {
                                rowString.Add(row[i].ToString());
                            }
                            catch
                            {
                            }
                        }

                        tableCells.Add(rowString);
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
