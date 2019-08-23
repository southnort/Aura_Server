using LumiSoft.Net.UPnP.NAT;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;

namespace Aura_Server.Controller.Network
{
    /// <summary>
    /// Предназначен для клиент-серверного взаимодействия.
    /// Устанавливается на стороне сервера.
    /// Принимает новые подключения и создает на каждое из них ClientObject.
    /// </summary>
    class ServerObject
    {
        private TcpListener tcpListener;    //сервер для прослушивания
        private Dictionary<string, ClientObject> clients;   //все подключения
        private MessageHandler messageHandler;  //обработчик сетевых сообщений

        private UPnP_NAT_Client client = new UPnP_NAT_Client();


        public ServerObject()
        {
            clients = new Dictionary<string, ClientObject>();
            messageHandler = new MessageHandler(this);

        }

        protected internal void AddConnection(ClientObject clientObject)
        {
            clients.Add(clientObject.connectionID, clientObject);
        }

        protected internal void RemoveConnection(string id)
        {
            if (clients.ContainsKey(id))
                clients.Remove(id);

        }

        protected internal void Disconnect()
        {
            // отключение всех клиентов, остановка сервера
            tcpListener.Stop(); //остановка сервера
            foreach (var pair in clients)
            {
                pair.Value.Close();
            }

            ClosePorts();

            Environment.Exit(0); //завершение процесса
        }

        protected internal void Listen()
        {
            //прослушивание входящих подключений
            try
            {


#if DEBUG
                tcpListener = new TcpListener(IPAddress.Any,
                   ConnectionSettings.Instance.serverDebugPort);
                tcpListener.Start();

#else

                 tcpListener = new TcpListener(IPAddress.Any,
                    ConnectionSettings.Instance.serverListenPort);
                tcpListener.Start();

                ClosePorts();
                OpenPorts();
#endif


                while (true)
                {
                    TcpClient tcpClient = tcpListener.AcceptTcpClient();

                    ClientObject clientObject = new ClientObject(tcpClient, this);
                    Thread clientThread = new Thread(new ThreadStart(clientObject.Process));
                    clientThread.Start();
                }

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Disconnect();
                Console.Read();
            }

        }

        private void OpenPorts()
        {
            try
            {
                IPAddress addres = IPAddress.Parse(ConnectionSettings.Instance.serverInternalAddress);
                IPEndPoint ipEndPoint = new IPEndPoint(addres, ConnectionSettings.Instance.serverListenPort);

                client.AddPortMapping(true, "test", "TCP",
                    ConnectionSettings.Instance.serverExternalAddress,
                    ConnectionSettings.Instance.serverListenPort,
                    ipEndPoint, 0);

                Console.WriteLine("Port opened");
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.Read();
            }


        }

        public void ClosePorts()
        {
            try
            {
                client.DeletePortMapping("TCP", ConnectionSettings.Instance.serverExternalAddress,
                    ConnectionSettings.Instance.serverListenPort);

                foreach (var map in client.GetPortMappings())
                {
                    client.DeletePortMapping(map);
                }

            }

            catch
            {
            }

        }



        protected internal void HandleMessage(string message, ClientObject client)
        {
            //обработка полученного сообщения
            messageHandler.HandleMessage(message, client.connectionID);

        }

                      
        protected internal void SendMessage(string message, string connectionID)
        {
            clients[connectionID].SendMessage(message);
        }

        protected internal void SendObject(object ob, string connectionID)
        {
            Console.WriteLine("Sending obj " + ob.ToString());
            clients[connectionID].SendObject(ob);
        }

        protected internal void SendFile(string message, string filePath, string connectionID)
        {
            clients[connectionID].SendMessage(message);
            Thread.Sleep(300);
            clients[connectionID].SendFile(filePath);
        }

    }
}

