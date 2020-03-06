using Aura_Server.Excel;
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

        private Dictionary<string, string> users;
        private Dictionary<string, string> organisations;



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
            ReloadUsers();
            ReloadOrganisations();


            string name = Guid.NewGuid().ToString() + ".xlsx";

            string filePath = name;

            var table = GetTable(queryString);
            var dataSet = ConvertDataTableToDataSet(table);
            
            var writer = new ExcelWriter();


            writer.ExportToFile(dataSet, filePath);


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

        private void ReloadUsers()
        {
            var table = GetTable("SELECT id, name FROM Users");
            users = new Dictionary<string, string>();
            users.Add("", "");
            users.Add("0", "");
            foreach (DataRow row in table.Rows)
            {
                users.Add(row[0].ToString(), row[1].ToString());
            }
        }

        private void ReloadOrganisations()
        {
            var table = GetTable("SELECT id, name FROM Organisations");
            organisations = new Dictionary<string, string>();
            organisations.Add("", "");
            organisations.Add("0", "");
            foreach (DataRow row in table.Rows)
            {
                organisations.Add(row[0].ToString(), row[1].ToString());
            }
        }


        private string ConvertToString(object val, string columnName)
        {
            //конвертирует значения полей в текст. Например, ID сотрудника в его фамилию

            var methods = Program.dataBase.GetTable("SELECT * FROM Methods");

            switch (columnName)
            {
                case "employeID": return users[GetStr(val)];
                case "organizationID": return organisations[GetStr(val)];
                case "purchaseMethodID": return methods.Rows[GetInt(val)][2].ToString();
                case "statusID": return Catalog.allStatuses[GetInt(val)];

                case "law": return Catalog.laws[GetInt(val)];
                case "withAZK": return GetInt(val) == 0 ? "С АЦК" : "БЕЗ АЦК";
                case "employeDocumentationID": return users[GetStr(val)];
                case "protocolStatusID": return Catalog.protocolStatuses[GetInt(val)];
                case "controlStatus": return GetInt(val) == 0 ? "Нет" : "Да";
                case "employeReestID": return users[GetStr(val)];
                case "reestrStatus": return GetInt(val) == 0 ? "Нет" : "Да";

                case "originalID": return Catalog.contractOriginalConditions[GetInt(val)];
                case "contractCondition": return Catalog.contractConditions[GetInt(val)];
                case "contractType": return Catalog.contractTypes[GetInt(val)];


                default: return val.ToString();
            }
        }


        private int GetInt(object val)
        {
            if (val is DBNull) return 0;
            else
                return (int)(long)val;

        }

        private string GetStr(object val)
        {
            if (val is DBNull) return "";
            else
                return val.ToString();
        }

    }

}
