using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Data;

namespace Aura_Server.Controller
{
    class DataBaseManager
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
            try
            {
                command.CommandText = commandString;
                command.ExecuteNonQuery();
                return "Success";
            }

            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public DataTable GetData(string queryString)
        {            
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(queryString, connection);
            DataTable dataTable = new System.Data.DataTable();
            adapter.Fill(dataTable);

            return dataTable;

        }

    }

}
