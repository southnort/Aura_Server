using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

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

            Environment.Exit(0); //завершение процесса
        }

        protected internal void Listen()
        {
            //прослушивание входящих подключений
            try
            {
                tcpListener = new TcpListener(IPAddress.Any, 40501);
                tcpListener.Start();

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
            Console.WriteLine("Sending message size is - " + size);
            byte[] preparedSize = BitConverter.GetBytes(size);


            foreach (var pair in clients)
            {
                pair.Value.broadcastStream.Write(preparedSize, 0, preparedSize.Length);               
            }

            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, ob);
            data = ms.GetBuffer();

            foreach (var pair in clients)
            {
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

