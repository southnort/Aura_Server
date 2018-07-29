using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aura_Server.Controller.Network
{
    /// <summary>
    /// Класс предназначен для обработки полученных сообщений от клиентов.    /// 
    /// </summary>
    class MessageHandler
    {
        protected internal string HandleMessage(string message)
        {
            //обработать полученное сообщение и ответить клиенту
            List<string> arr = SplitString(message);
            switch (arr[0])
            {
                case "LOGIN": return TryLogin(arr);

                default: return "ERROR#No such command " + arr[0];
            }

        }

        private List<string> SplitString(string message)
        {
            List<string> result = new List<string>();
            message = message.Replace("<", "").Replace(">", "");
            foreach (var str in message.Split('#'))
            {
                result.Add(str.Replace("#", ""));
            }

            return result;

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
