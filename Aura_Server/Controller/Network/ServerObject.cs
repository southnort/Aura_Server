using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Aura_Server.Network
{
    /// <summary>
    /// Предназначен для клиент-серверного взаимодействия.
    /// Представляет собой сервер, хранящий в себе список подключений
    /// </summary>
    class ServerObject
    {
        private static TcpListener tcpListener;                 //сервер для прослушивания порта
        private List<ClientObject> clients = new List<ClientObject>();  //все подключения
        private const int listenPort = 40501;       //порт, который нужно слушать



        protected internal void AddConnection(ClientObject client)
        {
            clients.Add(client);
        }

        protected internal void RemoveConnection(string connectionID)
        {
            ClientObject client = clients.FirstOrDefault(c => c.clientID == connectionID);
            if (client != null)
            {
                client.Close();
                clients.Remove(client);
            }
        }

        protected internal void Disconnect()
        {
            //отключение всех клиентов
            tcpListener.Stop();

            foreach (var client in clients)
                client.Close();
        }




        protected internal void Listen()
        {
            //прослушивание входящих сообщений
            try
            {
                tcpListener = new TcpListener(IPAddress.Any, listenPort);
                tcpListener.Start();
                Console.WriteLine("\n" + ToString() + " starting successfuly");
                string host = Dns.GetHostName();
                Console.WriteLine("Server IP Address - " + Dns.GetHostEntry(host).AddressList[0]);
                Console.WriteLine("Server port - " + listenPort);

                while (true)
                {
                    TcpClient tcpClient = tcpListener.AcceptTcpClient();
                    ClientObject client = new ClientObject(tcpClient, this);
                    Thread clientThread = new Thread(new ThreadStart(client.Process));
                    clientThread.Start();

                }

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Disconnect();
            }
        }    

        protected internal void BroadcastMessage(string message)
        {
            //трансляция сообщения подключенным клиентам
            byte[] data = Encoding.Unicode.GetBytes(message);
            for (int i = 0; i < clients.Count; i++)
            {
                SendMessage(data, clients[i]);
            }

        }     

        private void SendMessage(byte[] data, ClientObject client)
        {
            //отправка массива байт конкретному клиенту
            client.stream.Write(data, 0, data.Length);
        }





        protected internal void HandleMessage(string connectionID, string message)
        {
            //принимает строку сообщения от клиента и передает её в обработчик
           
        }



       

    }


}
