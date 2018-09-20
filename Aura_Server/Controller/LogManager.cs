using Aura_Server.Model;
using System;
using System.Data;


namespace Aura_Server.Controller
{
    public class LogManager
    {
        //класс отвечает за логирование действий пользователей в программе
        //выполнен в виде Singleton


        public static LogManager Instance = new LogManager();
        private DataBaseManager dataBase;       //БД для хранения логов. Она отделена от основной БД


        public static void LogPurchaseAdding(int userId, int purchaseID, string dataBaseQuery)
        {
            //залогировать добавление новой закупки
            LogNode node = new LogNode
            {
                userID = userId,
                tableName = "Purchases",
                itemID = purchaseID,                
                message = "Создание закупки",
                dataBaseQuery = dataBaseQuery,

            };

            Instance.Log(node);
        }

        public static void LogPurchaseUpdate(int userId, int purchaseID, string dataBaseQuery)
        {
            LogNode node = new LogNode
            {
                userID = userId,
                tableName = "Purchases",
                itemID = purchaseID,               
                message = "Редактирование закупки",
                dataBaseQuery = dataBaseQuery,

            };

            Instance.Log(node);
        }


        public static void LogOrganisationAdding(int userId, int organisationID, string dataBaseQuery)
        {
            LogNode node = new LogNode
            {
                userID = userId,
                tableName = "Organisations",
                itemID = organisationID,                
                message = "Создание организации",
                dataBaseQuery = dataBaseQuery,

            };

            Instance.Log(node);
        }

        public static void LogOrganisationUpdate(int userId, int organisationID, string dataBaseQuery)
        {
            LogNode node = new LogNode
            {
                userID = userId,
                tableName = "Organisations",
                itemID = organisationID,               
                message = "Редактирование организации",
                dataBaseQuery = dataBaseQuery,

            };

            Instance.Log(node);
        }


        public static void LogReportUpdate(int userID, int reportID, string dataBaseQuery)
        {
            LogNode node = new LogNode
            {
                userID = userID,
                tableName = "Reports",
                itemID = reportID,
                message = "Редактирование отчета",
                dataBaseQuery = dataBaseQuery,

            };

            Instance.Log(node);

        }


        private void Log(LogNode node)
        {
            try
            {
                dataBase.ExecuteCommand(node.ToDataBaseCommand());
                Console.WriteLine("LogManaget log successful " + node.ToDataBaseCommand());               
            }
            catch (Exception ex)
            {
                Console.WriteLine("LogManager Exception: \n" + node.ToDataBaseCommand() + "\n" + ex.ToString());
            }
        }


        public void InitializeLogManager(string dbForLogFileName)
        {
            dataBase = new DataBaseManager();
            dataBase.ConnectToDataBase(dbForLogFileName);

            Console.WriteLine("DBs initialized. Log Manager activated");

        }

        public DataTable GetTable(string request)
        {
            return dataBase.GetTable(request);
        }


    }
}
