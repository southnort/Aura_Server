using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aura_Server.Model
{
    public class DayInCalendar
    {
        //класс описывающий один день из календаря.
        //хранит в себе список закупок, для которых этот день важен
        public DayInCalendar(DateTime date)
        {
            this.date = date;
        }


        public DateTime date { get; private set; }
        private List<Purchase> purchases = new List<Purchase>();

        public Dictionary<Purchase, string> events = 
            new Dictionary<Purchase, string>();    //описание событий в этот день


        public void Add(Purchase purchase)
        {
            //добавить новую закупку, если она еще не добавлена
            if (!purchases.Contains(purchase))
            {
                purchases.Add(purchase);
            }

        }

        private void handlePurchase(Purchase pur)
        {
            //метод проверяет, какое именно событие назначено на эту дату
            // и добавляет соответствующее описание

            string dateStr = date.ToString();
            string eventStr = "";

            if (dateStr == pur.bidsStartDate)
                eventStr = "Начало подачи заявок";
            else if (dateStr == pur.bidsEndDate)
                eventStr = "Окончание подачи заявок";
            else if (dateStr == pur.bidsOpenDate)
                eventStr = "Вскрытие конвертов";
            else if (dateStr == pur.bidsFirstPartDate)
                eventStr = "Рассмотрение первых частей";
            else if (dateStr == pur.auctionDate)
                eventStr = "Аукцион";
            else if (dateStr == pur.bidsSecondPartDate)
                eventStr = "Рассмотрение вторых частей";
            else if (dateStr == pur.bidsFinishDate)
                eventStr = "Дата подведения итогов";
            else if (dateStr == pur.contractDateLast)
                eventStr = "Подписать контракт";
            else if (dateStr == pur.reestrDateLast)
                eventStr = "Внести контракт в реестр";


            if (eventStr != "")
                events.Add(pur, eventStr);

        }

        

    }
}
