using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aura_Server.Controller.Network
{
    /// <summary>
    /// Класс предназначен для обработки полученных сообщений от клиентов.  
    /// Также подготавливает ответные сообщения к отправке
    /// </summary>
    abstract class MessageHandlerBase
    {
        protected internal void HandleMessage(string message, string connectionID)
        {
            if (message != "" && message != string.Empty)
            {

                Console.WriteLine("Handle message " + message);
                List<string> arr = SplitString(message);

                switch (arr[0])
                {
                    case "msg": HandleMessage(arr); break;
                    case "rqst": HandleRequest(arr, connectionID); break;
                    case "sobj": ReceiveObject(arr, connectionID); break;
                    case "gobj": SendObject(arr, connectionID); break;
                    case "gfl": SendFile(arr, connectionID); break;

                    default: Console.WriteLine("Error. Invalid request: " + arr[0]); break;
                }
            }
        }


        //обработать запрос, не требующий ответа        
        abstract protected void HandleMessage(List<string> message);

        //обработать запрос, требующий ответа
        abstract protected void HandleRequest(List<string> message, string connectionID);

        //получить объект от клиента
        abstract protected void ReceiveObject(List<string> message, string connectionID);

        //отправить объект клиенту
        abstract protected void SendObject(List<string> message, string connectionID);

        //отправить клиенту файл
        abstract protected void SendFile(List<string> message, string connectionID);


        protected List<string> SplitString(string message)
        {
            //разделить запрос от клиента, подготовив его к обработке
            List<string> result = new List<string>();
            message = message.Replace("<", "").Replace(">", "");
            foreach (var str in message.Split(new char[] { '#' }, StringSplitOptions.RemoveEmptyEntries))
            {
                result.Add(str.Replace("#", ""));
            }

            return result;

        }

        protected string PrepareString(string original)
        {
            //подготовить сообщение к отправке
            return "<#" + original + "#>";
        }


    }


}
