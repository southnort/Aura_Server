using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aura_Server.Model;



namespace Aura_Server.Controller
{
    public class LogManager
    {
        //класс отвечает за логирование действий пользователей в программе
        //выполнен в виде Singleton


        public static LogManager Instance = new LogManager();
        private DataBaseManager dataBase;       //БД для хранения логов. Она отделена от основной БД

        public static void Log(int userId, string message, int idOfPurchase = -1, int idOfOrganisation = -1)
        {
            //userID - ID пользователя, совершившего действие
            //idOfPurchase - ID изменяемой закупки
            LogNode node = new LogNode
            {
                userID = userId,
                message = message,
                logDateTime = DateTime.Now.ToString(),
                purchaseID = idOfPurchase,
                organisationID = idOfOrganisation,

            };


            Instance.Log(node);

        }

        private void Log(LogNode node)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO Logs (userID, message, logDateTime, organisationID) ");
            sb.Append("VALUES ('");
            sb.Append(node.userID);
            sb.Append("', '");
            sb.Append(node.message);
            sb.Append("', '");
            sb.Append(node.logDateTime);
            sb.Append("', '");
            sb.Append(node.organisationID);
            sb.Append("')");

            try
            {
                dataBase.ExecuteCommand(sb.ToString());
                Console.WriteLine("LogManaget log successful " + sb.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("LogManager Exception: \n" + sb.ToString() + "\n" + ex.ToString());
            }
        }


        public void InitializeLogManager(string dbForLogFileName)
        {
            dataBase = new DataBaseManager();
            dataBase.ConnectToDataBase(dbForLogFileName);

           Console.WriteLine("DBs initialized. Log Manager activated");

        }




    }
}
