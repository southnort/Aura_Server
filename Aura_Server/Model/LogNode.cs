using System;
using System.Text;
using System.Data;


namespace Aura_Server.Model
{
    class LogNode
    {
        //класс, используемый в системе логирования
        //описывает одно конкретное действие одного пользователя в один момент

        public long id;                 //ИД ноды в базе
        public long userID;             //ИД юзера, который изменяет что-то
        public string tableName;        //в какой таблице изменяется что-то
        public long itemID;             //ИД изменяемой закупки или организации в таблице
        public string date;             //дата создания лога
        public string time;             //время создания лога
        public string message;          //содержание изменений
        public string dataBaseQuery;    //текст запроса к БД


        public LogNode()
        {
            date = DateTime.Now.ToShortDateString();
            time = DateTime.Now.ToLongTimeString();
        }

        public LogNode(DataRow row)
        {
            id = row[0] is DBNull ? 0 : (long)row[0];
            userID = row[1] is DBNull ? 0 : (long)row[1];
            tableName = row[2] is DBNull ? "" : (string)row[2];
            itemID = row[3] is DBNull ? 0 : (long)row[3];
            date = row[4] is DBNull ? DateTime.MinValue.ToShortDateString() : (string)row[4];
            time = row[5] is DBNull ? DateTime.MinValue.ToLongTimeString() : (string)row[5];
            message = row[6] is DBNull ? "" : (string)row[6];
            dataBaseQuery = row[7] is DBNull ? "" : (string)row[7];

        }

        public string ToDataBaseCommand()
        {
            //команда для добавления лога в таблицу ДБ
            while (dataBaseQuery.Contains("'"))
            {
                dataBaseQuery = dataBaseQuery.Replace("'", "|");
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO Logs ('userID', 'tableName', 'itemID', 'date', 'time', 'message', 'dataBaseQuery')");
            sb.Append(" VALUES ('");

            sb.Append(userID);
            sb.Append("', '");
            sb.Append(tableName);
            sb.Append("', '");
            sb.Append(itemID);
            sb.Append("', '");
            sb.Append(date);
            sb.Append("', '");
            sb.Append(time);
            sb.Append("', '");
            sb.Append(message);
            sb.Append("', '");
            sb.Append(dataBaseQuery);
            sb.Append("')");

            return sb.ToString();
        }

    }
}
