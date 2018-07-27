using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aura_Server.Controller;


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


        

        private void Add(string date, Purchase purchase)
        {
            if (!ContainsKey(date.ToDateTime()))
            {
                Add(date.ToDateTime(), new DayInCalendar(date.ToDateTime()));
            }

            this[date.ToDateTime()].Add(purchase);

        }

        

    }

}
