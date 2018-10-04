using Aura.Model;
using Aura_Server.Model;
using System;
using System.Collections.Generic;
using System.Data;


namespace Aura_Server.Controller
{
    public class PurchasesTableAdapter : DataBaseAdapter
    {
        //класс для взаимодействия с таблицей "Purchases" в БД


        public PurchasesTableAdapter(DataBaseManager manager) : base(manager)
        {
        }

        //public string AddNewPurchase(Purchase purchase, int tryingUserID)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    sb.Append("INSERT INTO Purchases ('employeID', 'organizationID', 'purchaseMethodID', 'purchaseName', ");
        //    sb.Append("'statusID', 'purchacePrice', 'purchaseEisNum', 'purchaseEisDate', 'bidsStartDate', ");
        //    sb.Append("'bidsEndDate', 'bidsOpenDate', 'bidsFirstPartDate', 'auctionDate', 'bidsSecondPartDate', ");
        //    sb.Append("'bidsFinishDate', 'contractPrice', 'contractDatePlan', 'contractDateLast', ");
        //    sb.Append("'contractDateReal', 'reestrDateLast', 'reestrNumber', 'comments') values ('");

        //    sb.Append(purchase.employeID);
        //    sb.Append("', '");
        //    sb.Append(purchase.organizationID);
        //    sb.Append("', '");
        //    sb.Append(purchase.purchaseMethodID);
        //    sb.Append("', '");
        //    sb.Append(purchase.purchaseName);
        //    sb.Append("', '");
        //    sb.Append(purchase.statusID);
        //    sb.Append("', '");
        //    sb.Append(purchase.purchacePrice);
        //    sb.Append("', '");
        //    sb.Append(purchase.purchaseEisNum);
        //    sb.Append("', '");
        //    sb.Append(purchase.purchaseEisDate);
        //    sb.Append("', '");
        //    sb.Append(purchase.bidsStartDate);
        //    sb.Append("', '");
        //    sb.Append(purchase.bidsEndDate);
        //    sb.Append("', '");
        //    sb.Append(purchase.bidsOpenDate);
        //    sb.Append("', '");
        //    sb.Append(purchase.bidsFirstPartDate);
        //    sb.Append("', '");
        //    sb.Append(purchase.auctionDate);
        //    sb.Append("', '");
        //    sb.Append(purchase.bidsSecondPartDate);
        //    sb.Append("', '");
        //    sb.Append(purchase.bidsFinishDate);
        //    sb.Append("', '");
        //    sb.Append(purchase.contractPrice);
        //    sb.Append("', '");
        //    sb.Append(purchase.contractDatePlan);
        //    sb.Append("', '");
        //    sb.Append(purchase.contractDateLast);
        //    sb.Append("', '");
        //    sb.Append(purchase.contractDateReal);
        //    sb.Append("', '");
        //    sb.Append(purchase.reestrDateLast);
        //    sb.Append("', '");
        //    sb.Append(purchase.reestrNumber);
        //    sb.Append("', '");
        //    sb.Append(purchase.comments);
        //    sb.Append("')");

        //    try
        //    {               
        //        return ExecuteCommand(sb.ToString());
        //    }

        //    catch (Exception ex)
        //    {
        //        throw (new Exception(ex.ToString() + "\n"
        //            + sb.ToString()));
        //    }

        //}

        public Purchase AddNewPurchase(string sqlCommand, int tryingUserID)
        {
            try
            {
                string result = ExecuteCommand(sqlCommand);

                //возвращаем только что добавленную закупку
                var table = dataBase.GetTable("SELECT * FROM Purchases WHERE ID=last_insert_rowid()");
                var row = table.Rows[0];

                Purchase newPurchase = new Purchase(row);
                LogManager.LogPurchaseAdding(tryingUserID, newPurchase.id, sqlCommand);
                return newPurchase;

            }

            catch (Exception ex)
            {
                throw (new Exception(ex.ToString() + "\n"
                    + sqlCommand));
            }

        }

        public Purchase UpdatePurchase(string sqlCommand, int tryingUserID)
        {
            try
            {
                //поиск в строке ID меняемой закупки
                int startIndex = sqlCommand.IndexOf("WHERE ID = ");
                string purchaseIDstr = sqlCommand.Substring(startIndex).Replace("WHERE ID = ", "");
                int purchaseID = int.Parse(purchaseIDstr);
                LogManager.LogPurchaseUpdate(tryingUserID, purchaseID, sqlCommand);

                ExecuteCommand(sqlCommand);
                return GetPurchase(purchaseID);
            }

            catch (Exception ex)
            {
                throw (new Exception(ex.ToString() + "\n"
                    + sqlCommand));
            }
        }

        public DataTable GetAllPurchasesInTable()
        {
            //возвращает все закупки в виде таблицы
            return GetData("SELECT * FROM Purchases");

        }

        public List<Purchase> GetAllPurchases()
        {
            //вернуть все закупки в виде List
            var result = new List<Purchase>();
            var table = GetAllPurchasesInTable();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                Purchase pur = new Purchase(table.Rows[i]);
                result.Add(pur);
            }
            
            return result;

        }

        public List<Purchase> GetReestr(string filterQuery)
        {
            //  var table = GetData("SELECT * FROM Purchases WHERE statusID > '7' ");
            var table = GetData(filterQuery);
            var result = new List<Purchase>(table.Rows.Count);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                Purchase pur = new Purchase(table.Rows[i]);
                result.Add(pur);
            }

            return result;

        }

        public Purchase GetPurchase(int id)
        {
            var table = dataBase.GetTable("SELECT * FROM Purchases WHERE ID= " + id);
            var row = table.Rows[0];
            return new Purchase(row);

        }

        public void DeletePurchase(int purID, int tryingUserID)
        {
            //удалить закупку из БД
            string command = "DELETE FROM Purchases WHERE id = '" + purID + "'";
            LogManager.LogPurchaseUpdate(tryingUserID, purID, command);
            ExecuteCommand(command);

        }


    }

}
