using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Aura.Model;
using Aura_Server.Model;


namespace Aura_Server.Controller
{
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
