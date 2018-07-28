using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Aura_Server.Network;


namespace Aura_Server.Controller
{
    /// <summary>
    /// Мост между основной программой и модулем сетевого взаимодействия.
    /// Переводит методы в текст для запроса по сети.
    /// Обрабатывает поступившие сетевые запросы и выполняет необходимые методы.
    /// </summary>
    public class NetworkBridge
    {
        private ServerObject server;
        private Thread listenThread;

        private static NetworkBridge _instance = new NetworkBridge();
        private NetworkBridge()
        {
            //приватный конструктор должен запретить создание экземпляров класса
            try
            {
                server = new ServerObject();
                listenThread = new Thread(new ThreadStart(server.Listen));
                listenThread.Start();
            }

            catch (Exception ex)
            {
                if (server != null)
                    server.Disconnect();
                throw ex;
            }
        }




        public void BroadcastMessage(string message)
        {
            _instance.server.BroadcastMessage(message);
        }



    }
}
