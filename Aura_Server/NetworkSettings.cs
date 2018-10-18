using System.Collections.Generic;
using System.IO;


namespace Aura_Server
{
    public static class NetworkSettings
    {
        //номера портов       

        private static int _firstPort;
        public static int firstPort
        {
            get
            {
                if (_firstPort == 0)
                    ReadConnectSettingsFile();
                return _firstPort;
            }
        }


        private static int _secondPort;
        public static int secondPort
        {
            get
            {
                if (_secondPort == 0)
                    ReadConnectSettingsFile();
                return _secondPort;
            }
        }



        //прочитать указанный файл и взять настройки для соединения
        private static void ReadConnectSettingsFile()
        {
            List<string> connectionSettings = new List<string>();
            using (StreamReader sr = new StreamReader("connect settings.txt"))
            {
                while (!sr.EndOfStream)
                    connectionSettings.Add(sr.ReadLine());
            }
           
            _firstPort = int.Parse(connectionSettings[0]);
            _secondPort = int.Parse(connectionSettings[1]);

        }




    }
}
