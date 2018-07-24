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
        private static string tempDBstring = "tempDataBase.sqlite";

        static void Main()
        {
            try
            {
                DataBaseCreator creator = new DataBaseCreator();
                DataBaseManager dataBase = new DataBaseManager();

                creator.CreateDateBase(tempDBstring);
                creator = null;
                dataBase.ConnectToDataBase(tempDBstring);
                
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            Console.Read();
        }
    }
}
