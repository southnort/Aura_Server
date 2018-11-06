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
    /// Выполняет массовое оповещение всех клиентов.
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
                client.AddPortMapping(true, "test", "TCP",
                    ConnectionSettings.Instance.serverExternalAddress,
                    ConnectionSettings.Instance.serverListenPort,
                    new IPEndPoint(
                        IPAddress.Parse(ConnectionSettings.Instance.serverInternalAddress),
                        ConnectionSettings.Instance.serverListenPort),
                   0);
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



        protected internal void BroadcastMessage(string message, object ob)
        {
            //трансляция сообщения всем подключенным клиентам
            Console.WriteLine("######## BROADCASTING " + message + " " + ob.GetType());
            byte[] data = Encoding.Unicode.GetBytes(message);
            int size = data.Length;
            byte[] preparedSize = BitConverter.GetBytes(size);

            foreach (var pair in clients)
            {
                pair.Value.broadcastStream.Write(preparedSize, 0, preparedSize.Length);
                pair.Value.broadcastStream.Write(data, 0, data.Length); //передача данных
            }

            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, ob);
            data = ms.GetBuffer();
            size = data.Length;
            preparedSize = BitConverter.GetBytes(size);


            foreach (var pair in clients)
            {
                pair.Value.broadcastStream.Write(preparedSize, 0, preparedSize.Length);
                pair.Value.broadcastStream.Write(data, 0, data.Length); //передача сериализованного объекта
            }


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


    }
}

