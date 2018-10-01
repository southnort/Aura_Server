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
                switch (ev.Key.purchaseMethodID)
                {
                    case 2: HandleDemandOfQuotation(ev); break;
                    case 3: HandleDemandOfQuotation(ev); break;
                    case 4: HandleAuction(ev);break;
                    case 5: HandleKonkurs(ev);break;
                    case 6: HandleKonkurs(ev);break;
                    case 7: HandleAuction(ev); break;

                }

            }

        }

        private void HandleDemandOfQuotation(KeyValuePair<Purchase, string> pair)
        {
            switch (pair.Value)
            {
                case "Окончание подачи заявок":
                    {
                        if (pair.Key.bidsFinishDate < DateTime.Now)
                            SwitchStatusOfPurchase(pair.Key, 2);
                    }
                    break;

                case "Вскрытие конвертов":
                    {
                        if (pair.Key.bidsOpenDate < DateTime.Now)
                            SwitchStatusOfPurchase(pair.Key, 3);
                    }
                    break;

                case "Рассмотрение":
                    {
                        if (pair.Key.bidsReviewDate < DateTime.Now)
                            SwitchStatusOfPurchase(pair.Key, 4);
                    }
                    break;

                case "Оценка":
                    {
                        if (pair.Key.bidsRatingDate < DateTime.Now)
                            SwitchStatusOfPurchase(pair.Key, 8);
                    }
                    break;

                default: break;

            }
        }

        private void HandleAuction(KeyValuePair<Purchase, string> pair)
        {
            switch (pair.Value)
            {
                case "Окончание подачи заявок":
                    {
                        здесь
                    }break;
            }
        }

        private void HandleKonkurs(KeyValuePair<Purchase, string> pair)
        {

        }


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
