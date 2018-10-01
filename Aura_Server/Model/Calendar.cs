using Aura.Model;
using System;
using System.Collections.Generic;

namespace Aura_Server.Model
{


    public class Calendar : Dictionary<DateTime, DayInCalendar>
    {
        //класс, описывающий календарь
        public void Add(Purchase purchase)
        {
            Add(purchase.purchaseEisDate, purchase);
            Add(purchase.bidsStartDate, purchase);
            Add(purchase.bidsEndDate, purchase);
            Add(purchase.bidsOpenDate, purchase);
            Add(purchase.bidsFirstPartDate, purchase);
            Add(purchase.auctionDate, purchase);
            Add(purchase.bidsSecondPartDate, purchase);
            Add(purchase.bidsFinishDate, purchase);
            Add(purchase.contractDatePlan, purchase);
            Add(purchase.contractDateLast, purchase);
            Add(purchase.contractDateReal, purchase);
            Add(purchase.reestrDateLast, purchase);

        }




        private void Add(DateTime date, Purchase purchase)
        {
            if (!ContainsKey(date))
            {
                Add(date, new DayInCalendar(date));
            }

            this[date].Add(purchase);

        }


    }



    public static class ExtensionsMethods
    {
        //статический класс для расширящих методов
        public static DateTime ToDateTime(this string str)
        {
            return Convert.ToDateTime(str);

        }
    }
}
