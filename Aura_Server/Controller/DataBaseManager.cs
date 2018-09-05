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

       
    }

}
