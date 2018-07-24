using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace Aura_Server.Model
{
    class DataBaseCreator
    {
        //класс, отвечающий за создание баз данных

        public void CreateDateBase(string dbFileName)
        {
            string commandString =
                CreateCommandString_LogTable() +
                CreateCommandString_UsersTable() +
                CreateCommandString_PurchasesTable();

            CreateDataBase(dbFileName, commandString);
        }



        private void CreateDataBase(string dbFileName, string commandString)
        {
            //если нет БД - создать её. Если есть БД, 
            //добавить в неё всё отсутствующие таблицы из commandString

            if (!File.Exists(dbFileName))
            {
                SQLiteConnection.CreateFile(dbFileName);
            }

            SQLiteConnection m_dbConn = new SQLiteConnection("Data Source=" + dbFileName + ";Version=3;");
            m_dbConn.Open();

            SQLiteCommand m_sqlCmd = new SQLiteCommand();
            m_sqlCmd.Connection = m_dbConn;
            m_sqlCmd.CommandText = commandString;
            m_sqlCmd.ExecuteNonQuery();

        }



        //описания таблиц в базе данных

        private string CreateCommandString_LogTable()
        {
            //создать commandString для таблицы логов

            return "";
        }

        private string CreateCommandString_UsersTable()
        {
            //создать commandString для таблицы юзеров
            StringBuilder sb = new StringBuilder();
            sb.Append("CREATE TABLE IF NOT EXISTS Users (");
            sb.Append("id INTEGER PRIMARY KEY AUTOINCREMENT, ");
            sb.Append("login TEXT, ");
            sb.Append("password TEXT, ");
            sb.Append("name TEXT, ");
            sb.Append("roleID INTEGER, ");
            sb.Append("dateOfCreation TEXT, ");
            sb.Append("dateOfLastEnter TEXT, ");
            sb.Append(")");

            return sb.ToString();
        }

        private string CreateCommandString_PurchasesTable()
        {
            //создать commandString для таблицы закупок

            return "";
        }

    }
}
