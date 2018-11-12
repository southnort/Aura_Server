using OdsReadWrite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using Aura.Model;


namespace Aura_Server.Controller
{
    public class DataBaseManager
    {
        //менеджер, осуществляющий связь между БД и программой
        //один менеджер на одну базу


        private SQLiteConnection connection;
        private SQLiteCommand command;

        public void ConnectToDataBase(string dbFileName)
        {
            //подключиться к существующей базе
            if (!File.Exists(dbFileName))
            {
                throw new Exception("DataBase \"" + dbFileName + "\" not found");

            }

            else
            {
                connection = new SQLiteConnection("Data Source=" + dbFileName + ";Version=3;");
                connection.Open();
                command = new SQLiteCommand();
                command.Connection = connection;

            }

        }

        public void CloseConnection()
        {
            connection.Close();

        }




        public string ExecuteCommand(string commandString)
        {
            //запрос к БД не возвращающий значений            
            command.CommandText = commandString;
            command.ExecuteNonQuery();
            return "Success";

        }

        public object GetValue(string queryString)
        {
            //запрос к БД, предполагающий возвращение единственного значения            
            command.CommandText = queryString;
            return command.ExecuteScalar();

        }

        public DataTable GetTable(string queryString)
        {
            //запрос к БД, предполагающий возвращение множества значений в виде таблицы            
            command.CommandText = queryString;
            DataSet dataSet = new DataSet();
            dataSet.Reset();
            SQLiteDataAdapter ad = new SQLiteDataAdapter(command);
            ad.Fill(dataSet);

            return dataSet.Tables[0];

        }


        public string CreateExcelFile(string queryString)
        {
            //создать файл и вернуть его имя-путь

            string name = Guid.NewGuid().ToString() + ".xls";

            string filePath = name;

            var table = GetTable(queryString);
            var dataSet = ConvertDataTableToDataSet(table);

            OdsReaderWriter writer = new OdsReaderWriter();

            writer.WriteOdsFile(dataSet, filePath);

            return filePath;

        }

        private DataSet ConvertDataTableToDataSet(DataTable table)
        {
            DataTable resultTable = new DataTable();
            CreateHeaders(table, resultTable);

            foreach (DataRow row in table.Rows)
            {
                DataRow newRow = resultTable.NewRow();
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    DataColumn column = table.Columns[i];
                    newRow[i] = ConvertToString(row[i], column.ColumnName);
                }
                resultTable.Rows.Add(newRow);
            }


            DataSet resultDataSet = new DataSet();
            resultDataSet.Tables.Add(resultTable);
            return resultTable.DataSet;
        }

        private void CreateHeaders(DataTable inputTable, DataTable resultTable)
        {
            List<string> names = new List<string>();
            foreach (DataColumn column in inputTable.Columns)
            {
                resultTable.Columns.Add(column.ColumnName, typeof(string));
                names.Add(HeaderText(column.ColumnName));
            }
            DataRow headerRow = resultTable.NewRow();
            headerRow.ItemArray = names.ToArray();
            resultTable.Rows.InsertAt(headerRow, 0);
        }

        private string HeaderText(string columnName)
        {
            if (Catalog.dataTableHeaders.ContainsKey(columnName))
                return Catalog.dataTableHeaders[columnName];
            else
                return columnName;
        }



        private string ConvertToString(object value, string columnName)
        {
            switch (columnName)
            {
                case "statusID": return Catalog.allStatuses[GetInt(value)];

                default: return value.ToString();
            }
        }



        private int GetInt(object val)
        {
            return (int)(long)val;
        }

    }

}
