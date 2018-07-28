using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;

namespace Aura_Server.Network
{
    /// <summary>
    /// Предназначен для клиент-серверного взаимодействия.
    /// Представляет собой отдельное подключение единичного клиента.
    /// </summary>
    class ClientObject
    {
        protected internal string clientID { get; private set; }        //ид сессии. Создается при подключении
        protected internal NetworkStream stream { get; private set; }
        protected internal string userID;                               //ид юзера. Постоянный. Берется из БД
        TcpClient client;
        ServerObject server;

        public ClientObject(TcpClient tcpClient, ServerObject serverObject)
        {
            clientID = Guid.NewGuid().ToString();
            client = tcpClient;
            server = serverObject;
            server.AddConnection(this);

        }

        public void Process()
        {
            try
            {
                stream = client.GetStream();
                while (true)
                {
                    try
                    {
                        string message = GetMessage();
                        server.HandleMessage(clientID, message);

                    }

                    catch
                    {
                        server.RemoveConnection(this.clientID);
                    }
                }


            }

            catch (Exception ex)
            {
                Console.WriteLine();
            }
        }

        private string GetMessage()
        {
            // чтение входящего сообщения и преобразование в строку
            byte[] data = new byte[64];
            StringBuilder sb = new StringBuilder();
            int bytes = 0;
            do
            {
                bytes = stream.Read(data, 0, data.Length);
                sb.Append(Encoding.Unicode.GetString(data, 0, bytes));
            }
            while (stream.DataAvailable);

            return sb.ToString();
            
        }
        
        protected internal void Close()
        {
            if (stream != null)
                stream.Close();
            if (client != null)
                client.Close();

        }


    }
}
