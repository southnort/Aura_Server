using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        protected internal NetworkStream stream { get; private set; }

        TcpClient client;
        ServerObject server; // объект сервера

        protected internal ClientObject(TcpClient tcpClient, ServerObject serverObject)
        {
            connectionID = Guid.NewGuid().ToString();
            client = tcpClient;
            server = serverObject;
            serverObject.AddConnection(this);
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

                    catch
                    {
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
        }



        protected internal void SendMessage(string message)
        {
            //отправить сообщение, не требующее ответа
            byte[] data = Encoding.Unicode.GetBytes(message);
            Send(data);

        }

        protected internal void SendObject(object ob)
        {
            //сериализовать и отправить объект. Ответ не требуется
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
            int bytes = 0;
            do
            {
                bytes = stream.Read(data, 0, data.Length);
                builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
            }
            while (stream.DataAvailable);
            string message = builder.ToString();

            return message;
        }

        protected internal object ReceiveObject()
        {
            //метод получения сериализованного объекта
            byte[] data = new byte[64];
            int bytes = 0;
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();

            //получаем
            try
            {
                do
                {
                    bytes = stream.Read(data, 0, data.Length);
                    ms.Write(data, 0, bytes);
                }
                while (stream.DataAvailable);

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
                stream.Write(data, 0, data.Length);

            }

            catch (Exception ex)
            {
                Console.WriteLine(ToString() + ".Send Exception: " + ex.Message);

            }

        }

    }
}

