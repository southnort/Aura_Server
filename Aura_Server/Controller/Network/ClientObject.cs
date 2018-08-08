using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Aura_Server.Controller.Network
{
    /// <summary>
    /// Предназначен для клиент-серверного взаимодействия.
    /// Устанавливается на стороне сервера.
    /// Устанавливает соединение с одним клиентом и обменивается с ним сообщениями
    /// </summary>
    class ClientObject
    {
        protected internal string connectionID { get; private set; }
        private NetworkStream stream;
        TcpClient client;
        ServerObject server; // объект сервера


        private TcpClient broadcastClient;
        private int broadcastPort = 40502;
        protected internal NetworkStream broadcastStream { get; private set; }      //поток для отправки оповещений



        protected internal ClientObject(TcpClient tcpClient, ServerObject serverObject)
        {
            connectionID = Guid.NewGuid().ToString();
            client = tcpClient;
            server = serverObject;
            serverObject.AddConnection(this);
            CreateBroadcastStream();
        }

        private void CreateBroadcastStream()
        {
            try
            {
                broadcastClient = new TcpClient();
                string clientIP = ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString();
                broadcastClient.Connect(clientIP, broadcastPort);
                broadcastStream = broadcastClient.GetStream();

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Close();
            }
        }

        protected internal void Process()
        {
            try
            {
                stream = client.GetStream();

                // в бесконечном цикле получаем сообщения от клиента
                while (true)
                {
                    try
                    {
                        string message = ReceiveString();
                        Console.WriteLine(message);
                        server.HandleMessage(message, this);
                    }

                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                        Close();
                        break;
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                // в случае выхода из цикла закрываем ресурсы
                server.RemoveConnection(connectionID);
                Close();
            }
        }

        protected internal void Close()
        {
            // закрытие подключения
            if (stream != null)
                stream.Close();
            if (client != null)
                client.Close();

            if (broadcastStream != null)
                broadcastStream.Close();
            if (broadcastClient != null)
                broadcastClient.Close();

        }



        protected internal void SendMessage(string message)
        {
            //отправить сообщение, не требующее ответа
            Console.WriteLine("Sending message: " + message);
            byte[] data = Encoding.Unicode.GetBytes(message);
            Send(data);

        }

        protected internal void SendObject(object ob)
        {
            //сериализовать и отправить объект. Ответ не требуется
            Console.WriteLine("Sending object ");
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();

            try
            {
                bf.Serialize(ms, ob);
                Send(ms.GetBuffer());

            }
            catch (Exception ex)
            {
                Console.WriteLine(ToString() + ".SendObject Exception: " + ex.Message);
            }

        }

        protected internal string ReceiveString()
        {
            //метод получения одного сообщения
            byte[] data = new byte[64]; // буфер для получаемых данных
            StringBuilder builder = new StringBuilder();
            int bytes = stream.Read(data, 0, 4);    //прочитать первые 6 байт - размер сообщения
            int size = BitConverter.ToInt32(data, 0);
            do
            {
                bytes = stream.Read(data, 0, data.Length);
                builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
            }
            while (bytes != size);
            string message = builder.ToString();

            Console.WriteLine("Recieving message: " + message);
            return message;
        }

        protected internal object ReceiveObject()
        {
            //метод получения сериализованного объекта
            byte[] data = new byte[64];
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();

            //получаем
            try
            {
                int bytes = stream.Read(data, 0, 4);    //прочитать первые 6 байт - размер сообщения
                int size = BitConverter.ToInt32(data, 0); 
                do
                {
                    bytes = stream.Read(data, 0, data.Length);
                    ms.Write(data, 0, bytes);
                }
                while (bytes != size);

                ms.Seek(0, SeekOrigin.Begin);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ToString() + "ReceiveObject Exception: " + ex.Message);
                return null;
            }

            //десериализуем
            try
            {
                object ob = bf.Deserialize(ms);
                return ob;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ToString() + "ReceiveObject.Deserialize Exception: " + ex.Message);
                return null;
            }

        }




        private void Send(byte[] data)
        {
            try
            {
                int size = data.Length;
                Console.WriteLine("Sending message size is - " + size);
                byte[] preparedSize = BitConverter.GetBytes(size);
                stream.Write(preparedSize, 0, preparedSize.Length);

                stream.Write(data, 0, data.Length);

            }

            catch (Exception ex)
            {
                Console.WriteLine(ToString() + ".Send Exception: " + ex.Message);

            }

        }

    }
}

