using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Aura.Model;
using Aura_Server.Model;

namespace Aura_Server.Controller
{
    public class UsersTableAdapter : DataBaseAdapter
    {
        //класс для взаимодействия с таблицей "Users" в БД


        public UsersTableAdapter(DataBaseManager manager) : base(manager)
        {

        }

        public string AddUser(User user)
        {
            if (user.ID < 1)
                return CreateNewUser(user);

            else
                return RefreshUser(user);
        }



        private string CreateNewUser(User user)
        {
            //добавить нового юзера в БД
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO Users ('login', 'password', 'name', 'roleID', 'dateOfCreation', 'dateOfLastEnter') values ('");
            sb.Append(user.login);
            sb.Append("', '");
            sb.Append(user.password);
            sb.Append("', '");
            sb.Append(user.name);
            sb.Append("', '");
            sb.Append(user.roleID);
            sb.Append("', '");
            sb.Append(user.dateOfCreation);
            sb.Append("', '");
            sb.Append(user.dateOfLastEnter);
            sb.Append("')");
            return ExecuteCommand(sb.ToString());

        }

        private string RefreshUser(User user)
        {
            //изменить данные в таблице БД
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE Users SET login = '");
            sb.Append(user.login);
            sb.Append("', password = '");
            sb.Append(user.password);
            sb.Append("', name = '");
            sb.Append(user.name);
            sb.Append("', roleID = '");
            sb.Append(user.roleID);
            sb.Append("', dateOfCreation = '");
            sb.Append(user.dateOfCreation);
            sb.Append("', dateOfLastEnter = '");
            sb.Append(user.dateOfLastEnter);
            sb.Append("' WHERE ID = ");
            sb.Append(user.ID);
            return ExecuteCommand(sb.ToString());

        }

        public DataTable GetUsersInTable()
        {
            return
                 dataBase.GetTable("SELECT * FROM Users");

        }

        public User GetUser(int userID)
        {
            DataTable table = dataBase.GetTable("SELECT * FROM Users WHERE ID = " + userID);
            var row = table.Rows[0];

            User user = new User();
            user.ID = int.Parse(row.ItemArray[0].ToString());
            user.login = (string)row.ItemArray[1];
            user.password = (string)row.ItemArray[2];
            user.name = (string)row.ItemArray[3];
            user.roleID = int.Parse(row.ItemArray[4].ToString());

            return user;

        }

        public int CheckLoginAndPassword(string login, string password)
        {
            //проверка на наличие в БД указанной пары логин/пароль
            //true - возвращается ID пользователя. false - возвращается -1
            //если пользователь заблокирован - возвращается -1


            object ob = dataBase.GetValue("SELECT id FROM Users WHERE login = '" +
                login + "' AND password = '" + password + "' AND roleID != '-1'");


            //object ob = dataBase.GetValue("SELECT id FROM Users WHERE password = " + password);

            if (ob != null)
            {
                LogManager.Log(-1, ob.ToString());
                return (int)(long)ob;
            }

            else
            {
                return -1;
            }
        }

        public List<User> GetAllUsers()
        {
            List<User> result = new List<User>();

            DataTable table = dataBase.GetTable("SELECT * FROM Users");
            for (int i = 0; i < table.Rows.Count; i++)
            {
                var row = table.Rows[i];

                User user = new User();
                user.ID = int.Parse(row.ItemArray[0].ToString());
                user.login = (string)row.ItemArray[1];
                user.password = (string)row.ItemArray[2];
                user.name = (string)row.ItemArray[3];
                user.roleID = int.Parse(row.ItemArray[4].ToString());

                result.Add(user);
            }

            return result;
        }

    }

}
