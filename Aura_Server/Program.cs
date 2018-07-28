using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aura_Server.Model;
using Aura_Server.Controller;
using Aura_Server.View;
using System.Data;

namespace Aura_Server
{
    class Program
    {
        static void Main()
        {
            UsersTableAdapter usersDataBase;
            PurchasesTableAdapter purchasesDataBase;

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



            //открываем формы 

            //LoginWindow loginWindow = new LoginWindow(usersDataBase);
            //loginWindow.ShowDialog();

           
            PurchasesCalendarForm calendarForm = new PurchasesCalendarForm(purchasesDataBase);
            calendarForm.ShowDialog();

           
        }

    }

}
