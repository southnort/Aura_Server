using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aura_Server.Model;



namespace Aura_Server.Controller
{
    class LogManager
    {
        //класс отвечает за логирование действий пользователей в программе
        //выполнен в виде Singleton


        public static LogManager Instance = new LogManager();
        private DataBaseManager dataBase;       //БД для хранения логов. Она отделена от основной БД

        public static void Log(int userId, string message, int idOfPurchase = -1)
        {
            LogNode node = new LogNode
            {
                userID = userId,
                message = message,
                logDateTime = DateTime.Now.ToString(),

            };
            if (idOfPurchase >= 0)
            {
                node.purchaseID = idOfPurchase;
            }

            Instance.Log(node);

        }

        private void Log(LogNode node)
        {
            Console.WriteLine(node.ToString() + "\n");
        }


        public void InitializeLogManager(string dbForLogFileName)
        {
            dataBase = new DataBaseManager();
            dataBase.ConnectToDataBase(dbForLogFileName);

            Log(-1, "DBs initialized. Log Manager activated");

        }




    }
}
