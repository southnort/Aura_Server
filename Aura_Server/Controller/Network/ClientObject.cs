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
     
        protected internal NetworkStream broadcastStream { get; private set; }      //поток для отправки оповещений



        protected internal ClientObject(TcpClient tcpClient, ServerObject serverObject)
        {
            connectionID = Guid.NewGuid().ToString();
            client = tcpClient;
            server = serverObject;
            serverObject.AddConnection(this);
            //  CreateBroadcastStream();
        }

        protected internal void Process()
        {
            try
            {
                stream = client.GetStream();

                //получаем сообщение от клиента

                try
                {
                    string message = ReceiveString(stream);
                    server.HandleMessage(message, this);
                    Close();
                }

                catch (Exception ex)
                {
                    // Console.WriteLine(ex.ToString());
                    Console.WriteLine("\n\nClient connection closed");
                    Console.WriteLine(ex.ToString());

                }


                
            }
            catch (Exception ex)
            {
                // Console.WriteLine(e.Message);
                Console.WriteLine("\n\nClient connection closed");
                Console.WriteLine(ex.ToString());
                Close();
            }

        }

        protected internal void Close()
        {
            // закрытие подключения
            server.RemoveConnection(connectionID);

            if (stream != null)
                stream.Close();
            if (client != null)
                client.Close();

            if (broadcastStream != null)
                broadcastStream.Close();
           

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

            //try
            //{
            bf.Serialize(ms, ob);
            Send(ms.GetBuffer());

            //}
            //catch (Exception ex)
            //{
            //   Console.WriteLine(ToString() + ".SendObject Exception: " + ex.Message);
            //}

        }

        protected internal void SendFile(string filePath)
        {
            //найти файл по названию, преобразовать его в набор байт и отправить
            //после отправки файл удаляется

            Console.WriteLine("Sending file ");
            using (var fileStream = new FileStream(filePath, FileMode.Open))
            {
                using (var reader = new BinaryReader(fileStream))
                {
                    var size = new FileInfo(filePath).Length;

                    byte[] buffer = new byte[size];
                    reader.Read(buffer, 0, (int)size);

                    Send(buffer);
                    Console.WriteLine("File sended successfull");
                }
            }

            if (File.Exists(filePath))
            {

                File.Delete(filePath);

            }

        }

        private string ReceiveString(NetworkStream st)
        {
            //метод получения одного сообщения
            // try
            {
                StringBuilder sb = new StringBuilder();

                var data = new byte[64];
                var size = new byte[4];
                int readCount;
                int totalReadMessageBytes = 0;

                st.Read(size, 0, 4);
                int messageLenght = BitConverter.ToInt32(size, 0);

                while ((readCount = st.Read(data, 0, data.Length)) != 0)
                {
                    sb.Append(Encoding.Unicode.GetString(data, 0, readCount));
                    totalReadMessageBytes += readCount;
                    if (totalReadMessageBytes >= messageLenght)
                        break;
                }
                Console.WriteLine("\n\n" + sb.ToString());
                Console.WriteLine("Size is - " + messageLenght + "\n\n");
                return sb.ToString();

            }
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.ToString());
            //    throw ex;
            //}
        }

        private object ReceiveObject(NetworkStream st)
        {
            //метод получения сериализованного объекта
            //   try
            {
                var ms = new MemoryStream();
                var binaryWriter = new BinaryWriter(ms);

                var data = new byte[64];
                var size = new byte[4];
                int readCount;
                int totalReadMessageBytes = 0;

                st.Read(size, 0, 4);
                int messageLenght = BitConverter.ToInt32(size, 0);
                Console.WriteLine("Object size -:" + messageLenght);

                while ((readCount = st.Read(data, 0, data.Length)) != 0)
                {
                    binaryWriter.Write(data, 0, readCount);
                    totalReadMessageBytes += readCount;
                    if (totalReadMessageBytes >= messageLenght)
                        break;
                }

                if (ms.Length > 0)
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    Console.WriteLine(ms.Length);
                    ms.Seek(0, SeekOrigin.Begin);
                    object ob = bf.Deserialize(ms);
                    return ob;
                }
                else
                {
                    return null;
                }
            }

            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.ToString());
            //    throw ex;
            //}

        }




        private void Send(byte[] data)
        {
            //  try
            {
                int size = data.Length;
                byte[] preparedSize = BitConverter.GetBytes(size);
                Console.WriteLine("Size is - : " + size);
                stream.Write(preparedSize, 0, preparedSize.Length);
                stream.Write(data, 0, data.Length);

            }

            //catch (Exception ex)
            //{
            //    Console.WriteLine(ToString() + ".Send Exception: " + ex.Message);

            //}

        }

    }
}

