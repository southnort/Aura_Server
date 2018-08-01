using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aura.Model;

namespace Aura_Server.Controller.Network
{

    partial class MessageHandler : MessageHandlerBase
    {
        private ServerObject server;
        protected internal MessageHandler(ServerObject servObj)
        {
            server = servObj;
        }

        protected override void HandleMessage(List<string> message)
        {
            //обработать запрос, не требующий ответа      
            switch (message[1])
            {
                default: Console.WriteLine(ToString() + " invalid command " + message[1]); break;
            }

        }

        protected override void HandleRequest(List<string> message, string connectionID)
        {
            //обработать запрос, требующий ответа
            string response = "";

            switch (message[1])
            {
                case "LOGIN": response = TryLogin(message); break;

                default: response = "ERROR#No such command " + message[1]; break;

            }

            server.SendMessage(PrepareString(response), connectionID);

        }

        protected override void ReceiveObject(List<string> message, string connectionID)
        {
            //получить объект от клиента
            switch (message[1])
            {
                default: Console.WriteLine(ToString() + " invalid command " + message[1]); break;
            }
        }

        protected override void SendObject(List<string> message, string connectionID)
        {                     
            //клиент запрашивает объект
            switch (message[1])
            {
                case ("USERNAMES"): server.SendObject(CreateUserNames(), connectionID); break;
                case ("ALLPURCHASES"): server.SendObject(CreatePurchases(), connectionID);break;

                default:
                    {
                        server.SendObject(null, connectionID);
                        Console.WriteLine(ToString() + " invalid command " + message[1]);
                    }
                    break;
            }
        }






        private string TryLogin(List<string> str)
        {
            int id = Program.usersDataBase.CheckLoginAndPassword(str[2], str[3]);
            if (id == -1)
            {
                return "LOGINFAILED";
            }

            else
            {
                StringBuilder sb = new StringBuilder();
                var user = Program.usersDataBase.GetUser(id);

                sb.Append("LOGINSUCCESS#");
                sb.Append(user.name + "#");
                sb.Append(user.roleID);

                return sb.ToString();
            }

        }

        private Dictionary<string, string> CreateUserNames()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            var table = Program.usersDataBase.GetUsersInTable();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                string id = table.Rows[i][0].ToString();
                string name = table.Rows[i][3].ToString();

                result.Add(id, name);
            }
            Console.WriteLine(result.Count);
            return result;

        }

        private Dictionary<string, Purchase> CreatePurchases()
        {
            var result = new Dictionary<string, Purchase>();
            var table = Program.purchasesDataBase.GetAllPurchases();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                Purchase pur = new Purchase(table.Rows[i]);
                result.Add(pur.id.ToString(), pur);
            }
            Console.WriteLine(result.Count);
            return result;
        }


    }

}
