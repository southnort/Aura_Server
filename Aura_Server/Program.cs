using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aura_Server.Model;
using Aura_Server.Controller;
using System.Data;

namespace Aura_Server
{
    class Program
    {       
        static void Main()
        {
            try
            {
                string dbForLogsFileName = "tempDataBaseForLogs.sqlite";
                string dbFileName = "tempDataBase.sqlite";

                DataBaseCreator creator = new DataBaseCreator();
                creator.CreateDataBaseForLogs(dbForLogsFileName);
                creator.CreateDataBase(dbFileName);
                creator = null;

                LogManager.Instance.InitializeLogManager(dbForLogsFileName);

                DataBaseManager dataBase = new DataBaseManager();
                dataBase.ConnectToDataBase(dbFileName);

                LogManager.Log(-1, "Connection to DBs is established");
                



            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            Console.Read();
        }
    }
}
