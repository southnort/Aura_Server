using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aura_Server.Model;
using Aura.Model;

namespace Aura_Server.Controller
{
    /// <summary>
    /// Менеджер, меняющий статусы закупок по расписанию. 
    /// </summary>
    class StatusSwitchManager
    {
        public void Tick()
        {
            //метод выполняется по таймеру

            Calendar calendar = Program.purchasesDataBase.GetCalendar();
            foreach (var day in calendar)
            {
                if (day.Key != DateTime.MinValue && day.Key <= DateTime.Today)
                {
                    HandleDay(day.Value);
                }
            }
        }

        private void HandleDay(DayInCalendar day)
        {           
            foreach (var ev in day.events)
            {
                if (ev.Key.id == 43)
                { }

                switch (ev.Key.purchaseMethodID)
                {
                    case 2: HandleDemandOfQuotation(ev); break;
                    case 3: HandleDemandOfQuotation(ev); break;
                    case 4: HandleAuction(ev); break;
                    case 5: HandleKonkurs(ev); break;
                    case 6: HandleKonkurs(ev); break;
                    case 7: HandleAuction(ev); break;

                }

            }
        }

        //private void HandlePurchase(KeyValuePair<Purchase, string> pair)
        //{
        //    if (pair.Value == "Начало подачи заявок") return;

        //    Purchase pur = pair.Key;
        //    int status = -1;

        //    switch (pair.Value)
        //    {
        //        case "Окончание подачи заявок": status = 2; break;
        //        case "Вскрытие конвертов": status = 2; break;
        //        case "Рассмотрение": status = 3; break;
        //        case "Оценка": status = 4; break;
        //        case "Первые части": status = 5; break;
        //        case "Вторые части": status = 6; break;
        //        case "Подведение итогов": status = 7; break;
        //        default: status = -1; break;
        //    }

        //    if (status != -1)
        //        SwitchStatusOfPurchase(pur, status);
        //}



        private void HandleDemandOfQuotation(KeyValuePair<Purchase, string> pair)
        {
            Purchase pur = pair.Key;
            int status = -1;
            switch (pair.Value)
            {
                case "Окончание подачи заявок": status = 2; break;
                case "Вскрытие конвертов": status = 2; break;
                case "Рассмотрение": status = 3; break;
                default: status = -1; break;
            }

            if (status != -1)
                SwitchStatusOfPurchase(pur, status);

        }

        private void HandleAuction(KeyValuePair<Purchase, string> pair)
        {
            Purchase pur = pair.Key;
            int status = -1;
            switch (pair.Value)
            {
                case "Первые части": status = 5; break;
                case "Вторые части": status = 6; break;
                case "Подведение итогов": status = 7; break;
                default: status = -1; break;
            }

            if (status != -1)
                SwitchStatusOfPurchase(pur, status);

        }

        private void HandleKonkurs(KeyValuePair<Purchase, string> pair)
        {
            Purchase pur = pair.Key;
            int status = -1;
            switch (pair.Value)
            {
                case "Вскрытие конвертов": status = 2; break;
                case "Рассмотрение": status = 3; break;
                case "Оценка": status = 4; break;
                default: status = -1; break;
            }

            if (status != -1)
                SwitchStatusOfPurchase(pur, status);

        }

        private void EmptyMethod()
        { }

      
       
        private void SwitchStatusOfPurchase(Purchase pur, int newStatusID)
        {
            SendCommandToSwitchStatus(pur.id.ToString(), newStatusID.ToString());
        }


        private void SendCommandToSwitchStatus(string id, string newStatusID)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE Purchases SET statusID = '");
            sb.Append(newStatusID);
            sb.Append("' WHERE id = '");
            sb.Append(id);
            sb.Append("'");

            Program.dataBase.ExecuteCommand(sb.ToString());
        }

    }

    /*     АЛГОРИТМ:

    1) Берем через Calendar список закупок, в которых есть события на сегодняшний день или ранее.
    2) Игнорируем нулевую дату.
    3) Проходим оставшийся список. 
    4) Если время, указанное в закупке по данному событию прошло - 
    переводим на следующий статус, если статус не конечный.
    5) Сохраняем обновленные данные в БД

    */

}
