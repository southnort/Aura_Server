﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Aura.Model;
using Aura_Server.Model;

namespace Aura_Server.Controller
{
    public abstract class DataBaseAdapter
    {
        //класс-переводчик между программой и базой данных
        //переводит пользовательские команды в запросы SQL и наоборот


        protected DataBaseManager dataBase;
        protected LogManager logManager;

        public DataBaseAdapter(DataBaseManager manager)
        {
            dataBase = manager;
            logManager = new LogManager();
        }

        protected string ExecuteCommand(string sqlCommand)
        {
            return dataBase.ExecuteCommand(sqlCommand);
        }

        protected DataTable GetData(string sqlQuery)
        {
            return dataBase.GetTable(sqlQuery);

        }

    }



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


    public class PurchasesTableAdapter : DataBaseAdapter
    {
        //класс для взаимодействия с таблицей "Purchases" в БД


        public PurchasesTableAdapter(DataBaseManager manager) : base(manager)
        {
        }

        public string AddNewPurchase(Purchase purchase)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO Purchases ('employeID', 'organizationID', 'purchaseMethodID', 'purchaseName', ");
            sb.Append("'statusID', 'purchacePrice', 'purchaseEisNum', 'purchaseEisDate', 'bidsStartDate', ");
            sb.Append("'bidsEndDate', 'bidsOpenDate', 'bidsFirstPartDate', 'auctionDate', 'bidsSecondPartDate', ");
            sb.Append("'bidsFinishDate', 'contractPrice', 'contractDatePlan', 'contractDateLast', ");
            sb.Append("'contractDateReal', 'reestrDateLast', 'reestrNumber', 'comments') values ('");

            sb.Append(purchase.employeID);
            sb.Append("', '");
            sb.Append(purchase.organizationID);
            sb.Append("', '");
            sb.Append(purchase.purchaseMethodID);
            sb.Append("', '");
            sb.Append(purchase.purchaseName);
            sb.Append("', '");
            sb.Append(purchase.statusID);
            sb.Append("', '");
            sb.Append(purchase.purchacePrice);
            sb.Append("', '");
            sb.Append(purchase.purchaseEisNum);
            sb.Append("', '");
            sb.Append(purchase.purchaseEisDate);
            sb.Append("', '");
            sb.Append(purchase.bidsStartDate);
            sb.Append("', '");
            sb.Append(purchase.bidsEndDate);
            sb.Append("', '");
            sb.Append(purchase.bidsOpenDate);
            sb.Append("', '");
            sb.Append(purchase.bidsFirstPartDate);
            sb.Append("', '");
            sb.Append(purchase.auctionDate);
            sb.Append("', '");
            sb.Append(purchase.bidsSecondPartDate);
            sb.Append("', '");
            sb.Append(purchase.bidsFinishDate);
            sb.Append("', '");
            sb.Append(purchase.contractPrice);
            sb.Append("', '");
            sb.Append(purchase.contractDatePlan);
            sb.Append("', '");
            sb.Append(purchase.contractDateLast);
            sb.Append("', '");
            sb.Append(purchase.contractDateReal);
            sb.Append("', '");
            sb.Append(purchase.reestrDateLast);
            sb.Append("', '");
            sb.Append(purchase.reestrNumber);
            sb.Append("', '");
            sb.Append(purchase.comments);
            sb.Append("')");

            try
            {
                return ExecuteCommand(sb.ToString());

            }

            catch (Exception ex)
            {
                throw (new Exception(ex.ToString() + "\n"
                    + sb.ToString()));
            }


        }

        public DataTable GetAllPurchases()
        {
            //возвращает все закупки в виде таблицы
            return GetData("SELECT * FROM Purchases");

        }

        public Calendar GetCalendar()
        {
            //возвращает все закупки из БД в виде календаря
            DataTable table = GetAllPurchases();
            Calendar calendar = new Calendar();

            foreach (DataRow row in table.Rows)
            {
                calendar.Add(new Purchase(row));

            }

            return calendar;

        }

        public Purchase GetPurchase(int id)
        {
            var table = dataBase.GetTable("SELECT * FROM Purchases WHERE ID= " + id);
            var row = table.Rows[0];
            return new Purchase(row);
        }

    }


}


