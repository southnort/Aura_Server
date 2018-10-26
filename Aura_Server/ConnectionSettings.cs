using System;
using System.IO;
using System.Xml.Serialization;



[Serializable]
public class ConnectionSettings
{
    public ConnectionSettings()
    {

    }

    public static ConnectionSettings Instance
    {
        get
        {
            if (_instance == null)
                _instance = LoadFromXml();

            return _instance;
        }
    }
    private static ConnectionSettings _instance;

    public string serverExternalAddress { get; set; }
    public string serverInternalAddress { get; set; }
    public string clientExternalAddress { get; set; }
    public string clientInternalAddress { get; set; }

    public int serverListenPort { get; set; }
    public int clientListenPort { get; set; }

    private const string fileName = "connection settings.xml";


    private void SaveToXml()
    {
        using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
        {
            XmlSerializer formatter = new XmlSerializer(typeof(ConnectionSettings));
            formatter.Serialize(fs, this);
        }

    }

    private static ConnectionSettings LoadFromXml()
    {
        using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
        {
            XmlSerializer formatter = new XmlSerializer(typeof(ConnectionSettings));
            ConnectionSettings result = (ConnectionSettings)formatter.Deserialize(fs);

            return result;

        }

    }


}

