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
        public static OrganisationsDataBaseAdapter organisationsDataBase;

        static void Main()
        {
            StartDataBases();
            StartNetwork();
          //  TestMethod();
            ShowForms();

            Console.WriteLine("Server starting successfully");

        }

        private static void StartDataBases()
        {
            //настраиваем соединения с БД            
            string dbForLogsFileName = "AuraDataBase_ForLogs.sqlite";
            string dbFileName = "AuraDataBase.sqlite";

            DataBaseCreator creator = new DataBaseCreator();
            creator.CreateDataBaseForLogs(dbForLogsFileName);
            creator.CreateMainDataBase(dbFileName);
            creator.UpdateTables(dbFileName);
            creator = null;

            LogManager.Instance.InitializeLogManager(dbForLogsFileName);

            DataBaseManager dataBase = new DataBaseManager();
            dataBase.ConnectToDataBase(dbFileName);

            usersDataBase = new UsersTableAdapter(dataBase);
            purchasesDataBase = new PurchasesTableAdapter(dataBase);
            organisationsDataBase = new OrganisationsDataBaseAdapter(dataBase);

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

            //PurchasesCalendarForm calendarForm = new PurchasesCalendarForm(purchasesDataBase);
            //calendarForm.ShowDialog();

            //PurchasesDataBaseForm purchasesDataBaseForm = new PurchasesDataBaseForm(purchasesDataBase);
            //purchasesDataBaseForm.ShowDialog();

        }

        private static void TestMethod()
        {
            Aura.Model.Purchase pur1 = new Aura.Model.Purchase()
            {
                purchaseName = "Техобслуживание",
                purchaseMethodID = 1,
                purchacePrice = 50000f,
                statusID  =0,
                employeID = 1,
                organizationID = 2,

                bidsStartDate = new DateTime(2018,8,13).ToString(),
                bidsEndDate = new DateTime(2018,8,20).ToString(),
                bidsFinishDate = new DateTime(2018,8,23).ToString(),

            };

            Aura.Model.Purchase pur2 = new Aura.Model.Purchase()
            {
                purchaseName = "Мягкий инвентарь",
                purchaseMethodID = 2,
                purchacePrice = 32504.54f,
                statusID = 2,
                employeID = 2,
                organizationID = 1,

                bidsStartDate = new DateTime(2018, 8, 15).ToString(),
                bidsEndDate = new DateTime(2018, 8, 16).ToString(),
                bidsFinishDate = new DateTime(2018, 8, 23).ToString(),
            
            };

            Aura.Model.Purchase pur3 = new Aura.Model.Purchase()
            {
                purchaseName = "Testing",
                purchaseMethodID = 3,
                statusID = 0,
                employeID = 0,
                organizationID = 3,

                purchaseEisDate = new DateTime(2018, 8, 15).ToString(),
                

            };

            Aura.Model.Purchase pur4 = new Aura.Model.Purchase()
            {

            };            

            Aura.Model.Purchase pur8 = new Aura.Model.Purchase()
            {

            };

           
        }

    }

}
