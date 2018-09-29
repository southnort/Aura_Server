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

        public void CreateMainDataBase(string dbFileName)
        {
            string commandString = CreateCommandString_UsersTable();
            CreateDataBase(dbFileName, commandString);

            commandString = CreateCommandString_PurchasesTable();
            CreateDataBase(dbFileName, commandString);

            commandString = CreateCommandString_OrganizationsTable();
            CreateDataBase(dbFileName, commandString);

            commandString = CreateCommandString_Reports();
            CreateDataBase(dbFileName, commandString);

            commandString = CreateCommandString_Contracts();
            CreateDataBase(dbFileName, commandString);

        }

        public void CreateDataBaseForLogs(string dbFileName)
        {
            string commandString = CreateCommandString_LogTable();
            CreateDataBase(dbFileName, commandString);

        }

        public void UpdateTables(string dbFileName)
        {
            //обновить существующие таблицы, добавить в них новые колонки


            SQLiteConnection m_dbConn = new SQLiteConnection("Data Source=" + dbFileName + ";Version=3;");
            m_dbConn.Open();

            SQLiteCommand m_sqlCmd = new SQLiteCommand();
            m_sqlCmd.Connection = m_dbConn;


            //Это нужно запустить через консоль прямого общения с БД

            //ALTER TABLE Purchases ADD COLUMN organisationInn TEXT

            //UPDATE Purchases
            //SET organisationInn =
            //(SELECT inn FROM Organisations WHERE id = Purchases.organizationID)

            //ALTER TABLE Organisations ADD COLUMN number TEXT

            //UPDATE Organisations SET number = id


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
            sb.Append("tableName TEXT, ");
            sb.Append("itemID INTEGER, ");
            sb.Append("date TEXT, ");
            sb.Append("time TEXT, ");
            sb.Append("message TEXT, ");
            sb.Append("dataBaseQuery TEXT");
            sb.Append(")");

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
            sb.Append("name TEXT, ");
            sb.Append("roleID INTEGER, ");
            sb.Append("dateOfCreation TEXT, ");
            sb.Append("dateOfLastEnter TEXT, ");
            sb.Append("law INTEGER)");

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
            sb.Append("comments TEXT, ");
            sb.Append("law INTEGER, ");
            sb.Append("withAZK INTEGER, ");
            sb.Append("employeDocumentationID INTEGER, ");
            sb.Append("resultOfControl TEXT, ");
            sb.Append("protocolStatusID INTEGER, ");
            sb.Append("bidsReviewDate TEXT, ");
            sb.Append("bidsRatingDate TEXT, ");
            sb.Append("controlStatus INTEGER, ");
            sb.Append("colorMark INTEGER, ");

            sb.Append("commentsFontColor INTEGER, ");
            sb.Append("resultOfControlColor INTEGER, ");
            sb.Append("employeReestID INTEGER, ");
            sb.Append("reestrStatus INTEGER, ");
            sb.Append("withoutPurchase INTEGER, ");
            sb.Append("organisationInn TEXT");

            sb.Append(")");

            return sb.ToString();
        }

        private string CreateCommandString_OrganizationsTable()
        {
            //создать commandString для таблицы организаций-заказчиков
            StringBuilder sb = new StringBuilder();
            sb.Append("CREATE TABLE IF NOT EXISTS Organisations (");

            sb.Append("id INTEGER PRIMARY KEY AUTOINCREMENT, ");
            sb.Append("name TEXT, ");
            sb.Append("inn TEXT, ");
            sb.Append("phoneNumber TEXT, ");
            sb.Append("contactName TEXT, ");
            sb.Append("email TEXT, ");
            sb.Append("originalID INTEGER, ");
            sb.Append("contractNumber TEXT, ");
            sb.Append("contractStart TEXT, ");
            sb.Append("contractEnd TEXT, ");
            sb.Append("comments TEXT, ");
            sb.Append("contractCondition INTEGER, ");
            sb.Append("law INTEGER, ");
            sb.Append("contractType INTEGER, ");
            sb.Append("contractsIDs TEXT, ");
            sb.Append("number TEXT");

            sb.Append(")");

            return sb.ToString();

        }

        private string CreateCommandString_Reports()
        {
            //строка для БД создание отчетов заказчиков
            StringBuilder sb = new StringBuilder();
            sb.Append("CREATE TABLE IF NOT EXISTS Reports (");

            sb.Append("organisationID INTEGER PRIMARY KEY, ");
            sb.Append("commonPurchasesContractsReport TEXT, ");
            sb.Append("singleSupplierContractsReport TEXT, ");
            sb.Append("failedPurchasesContractsReport TEXT");

            sb.Append(")");
            return sb.ToString();

        }

        private string CreateCommandString_Contracts()
        {
            //строка для БД создание договоров с заказчиками
            StringBuilder sb = new StringBuilder();
            sb.Append("CREATE TABLE IF NOT EXISTS Contracts (");

            sb.Append("id INTEGER PRIMARY KEY AUTOINCREMENT, ");
            sb.Append("organisationID INTEGER, ");
            sb.Append("contractNumber TEXT, ");
            sb.Append("contractStart TEXT, ");
            sb.Append("contractEnd TEXT");

            sb.Append(")");

            return sb.ToString();

        }


    }

}
