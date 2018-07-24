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


        public void CreateDataBase(string dbFileName)
        {
            string commandString = CreateCommandString_UsersTable();
            CreateDataBase(dbFileName, commandString);

            commandString = CreateCommandString_PurchasesTable();
            CreateDataBase(dbFileName, commandString);

        }

        public void CreateDataBaseForLogs(string dbFileName)
        {
            string commandString = CreateCommandString_LogTable();
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


            StringBuilder sb = new StringBuilder();
            sb.Append("CREATE TABLE IF NOT EXISTS Logs (");
            sb.Append("id INTEGER PRIMARY KEY AUTOINCREMENT, ");
            sb.Append("userID INTEGER, ");
            sb.Append("message TEXT, ");
            sb.Append("logDateTime TEXT)");

            return sb.ToString();

        }

        private string CreateCommandString_UsersTable()
        {
            //создать commandString для таблицы юзеров


            StringBuilder sb = new StringBuilder();
            sb.Append("CREATE TABLE IF NOT EXISTS Users (");
            sb.Append("id INTEGER PRIMARY KEY AUTOINCREMENT, ");
            sb.Append("login TEXT UNIQUE, ");
            sb.Append("password TEXT, ");
            sb.Append("name TEXT UNIQUE, ");
            sb.Append("roleID INTEGER, ");
            sb.Append("dateOfCreation TEXT, ");
            sb.Append("dateOfLastEnter TEXT)");

            return sb.ToString();

        }

        private string CreateCommandString_PurchasesTable()
        {
            //создать commandString для таблицы закупок
            StringBuilder sb = new StringBuilder();
            sb.Append("CREATE TABLE IF NOT EXISTS Purchases (");
            sb.Append("id INTEGER PRIMARY KEY AUTOINCREMENT, ");
            sb.Append("employeID INTEGER, ");
            sb.Append("organizationID INTEGER, ");
            sb.Append("purchaseMethodID INTEGER, ");
            sb.Append("purchaseName TEXT, ");
            sb.Append("statusID INTEGER, ");
            sb.Append("purchacePrice REAL, ");

            sb.Append("purchaseEisNum TEXT, ");
            sb.Append("purchaseEisDate TEXT, ");
            sb.Append("bidsStartDate TEXT, ");
            sb.Append("bidsEndDate TEXT, ");
            sb.Append("bidsOpenDate TEXT, ");
            sb.Append("bidsFirstPartDate TEXT, ");
            sb.Append("auctionDate TEXT, ");
            sb.Append("bidsSecondPartDate TEXT, ");
            sb.Append("bidsFinishDate TEXT, ");

            sb.Append("contractPrice REAL, ");
            sb.Append("contractDatePlan TEXT, ");
            sb.Append("contractDateLast TEXT, ");
            sb.Append("contractDateReal TEXT, ");
            sb.Append("reestrDateLast TEXT, ");
            sb.Append("reestrNumber TEXT, ");
            sb.Append("comments TEXT)");

            return sb.ToString();
        }

    }

}
