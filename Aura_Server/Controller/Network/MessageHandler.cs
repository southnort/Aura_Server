using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            throw new NotImplementedException();
        }

        protected override void SendObject(List<string> message, string connectionID)
        {
            //отправить объект клиенту
            throw new NotImplementedException();
        }






        private string TryLogin(List<string> str)
        {
            int id = Program.usersDataBase.CheckLoginAndPassword(str[1], str[2]);
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
    }

}
