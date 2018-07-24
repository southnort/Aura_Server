using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Aura_Server.Model;

namespace Aura_Server.Controller
{
    abstract class DataBaseAdapter
    {
        //класс-переводчик между программой и базой данных
        //переводит пользовательские команды в запросы SQL и наоборот
        protected DataBaseManager dataBase;

        public DataBaseAdapter(DataBaseManager manager)
        {
            dataBase = manager;
        }

        protected string ExecuteCommand(string sqlCommand)
        {
            return dataBase.ExecuteCommand(sqlCommand);
        }

        protected DataTable GetData(string sqlQuery)
        {
            return dataBase.GetData(sqlQuery);

        }

    }



    class UsersTableAdapter : DataBaseAdapter
    {
        //класс для взаимодействия с таблицей "Users" в БД
        public UsersTableAdapter(DataBaseManager manager) : base(manager)
        {

        }

        public string CreateNewUser(User user)
        {
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

    }


    class PurchasesTableAdapter : DataBaseAdapter
    {
        //класс для взаимодействия с таблицей "Purchases" в БД
        public PurchasesTableAdapter(DataBaseManager manager) : base(manager)
        {
        }

        public string CreateNewPurchase(Purchase purchase)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO Purchases ('employeID', 'organizationID', 'purchaseMethodID', 'purchaseName', ");
            sb.Append("'statusID', 'purchacePrice', 'purchaseEisNum', 'purchaseEisDate', 'bidsStartDate', ");
            sb.Append("'bidsEndDate, 'bidsOpenDate', 'bidsFirstPartDate', 'auctionDate', 'bidsSecondPartDate', ");
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

    }


}


