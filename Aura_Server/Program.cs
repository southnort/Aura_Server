using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aura_Server.Model;
using Aura_Server.Controller;
using Aura_Server.View;
using System.Data;
using Aura_Server.Controller.Network;
using System.Threading;

namespace Aura_Server
{
    class Program
    {
        public static UsersTableAdapter usersDataBase;
        public static PurchasesTableAdapter purchasesDataBase;

        static void Main()
        {
            StartDataBases();
            StartNetwork();
           // TestMethod();
             ShowForms();

            Console.WriteLine("Server starting successfully");
           
        }

        private static void StartDataBases()
        {
            //настраиваем соединения с БД            
            string dbForLogsFileName = "tempDataBaseForLogs.sqlite";
            string dbFileName = "tempDataBase.sqlite";

            DataBaseCreator creator = new DataBaseCreator();
            creator.CreateDataBaseForLogs(dbForLogsFileName);
            creator.CreateDataBase(dbFileName);
            creator = null;

            LogManager.Instance.InitializeLogManager(dbForLogsFileName);

            DataBaseManager dataBase = new DataBaseManager();
            dataBase.ConnectToDataBase(dbFileName);

            usersDataBase = new UsersTableAdapter(dataBase);
            purchasesDataBase = new PurchasesTableAdapter(dataBase);

            LogManager.Log(-1, "Connection to DBs established successfully");
        }

        private static void StartNetwork()
        {
            //включаем сетевое соединение
            ServerObject server;
            Thread listeningThread;
            try
            {
                server = new ServerObject();
                listeningThread = new Thread(new ThreadStart(server.Listen));
                listeningThread.Start();
            }
            catch (Exception ex)
            {                
                Console.WriteLine(ex.ToString());
            }

        }

        private static void ShowForms()
        {
            //открываем формы 

            LoginWindow loginWindow = new LoginWindow(usersDataBase);
            loginWindow.ShowDialog();


            PurchasesCalendarForm calendarForm = new PurchasesCalendarForm(purchasesDataBase);
            calendarForm.ShowDialog();

        }

        private static void TestMethod()
        {
            Aura.Model.Purchase pur1 = new Aura.Model.Purchase()
            {
                purchaseName = "тестовая закупка",
                bidsStartDate = new DateTime(2018, 8, 5).ToString(),
                bidsFinishDate = new DateTime(2018, 8, 9).ToString(),
            };

            Aura.Model.Purchase pur2 = new Aura.Model.Purchase()
            {
                purchaseName = "тестовая закупка 2",
                bidsStartDate = new DateTime(2018, 8, 11).ToString(),
                bidsFinishDate = new DateTime(2018, 8, 15).ToString(),
            };

            purchasesDataBase.AddNewPurchase(pur1);
            purchasesDataBase.AddNewPurchase(pur2);
        }

    }

}
