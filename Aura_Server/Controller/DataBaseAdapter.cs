using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Aura.Model;
using Aura_Server.Model;

namespace Aura_Server.Controller
{
    public abstract class DataBaseAdapter
    {
        //класс-переводчик между программой и базой данных
        //переводит пользовательские команды в запросы SQL и наоборот


        protected DataBaseManager dataBase;        

        public DataBaseAdapter(DataBaseManager manager)
        {
            dataBase = manager;            
        }
                
        protected string ExecuteCommand(string sqlCommand)
        {
            return dataBase.ExecuteCommand(sqlCommand);
        }

        protected DataTable GetData(string sqlQuery)
        {
            return dataBase.GetTable(sqlQuery);

        }

        

    }
    

}


