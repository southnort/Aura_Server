﻿using Aura.Model;
using System;
using System.Collections.Generic;
using System.Text;

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

            Calendar calendar = new Calendar(Program.purchasesDataBase.GetAllPurchases());
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
                    case 4: HandleAuction(ev); break;
                    case 5: HandleKonkurs(ev); break;
                    case 6: HandleKonkurs(ev); break;
                    case 7: HandleAuction(ev); break;

                }

            }
        }

        private void HandleDemandOfQuotation(KeyValuePair<Purchase, string> pair)
        {
            Purchase pur = pair.Key;
            int status = -1;
            switch (pair.Value)
            {
                case "Окончание подачи заявок": status = 1; break;
                case "Вскрытие конвертов": status = 1; break;
                case "Рассмотрение": status = 2; break;
                case "Оценка": status = 3; break;
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
                case "Первые части": status = 4; break;
                case "Вторые части": status = 5; break;
                case "Подведение итогов": status = 6; break;
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
                case "Вскрытие конвертов": status = 1; break;
                case "Рассмотрение": status = 2; break;
                case "Оценка": status = 3; break;
                default: status = -1; break;
            }

            if (status != -1)
                SwitchStatusOfPurchase(pur, status);

        }


        private void SwitchStatusOfPurchase(Purchase pur, int newStatusID)
        {
            if (pur.statusID < newStatusID)
                SendCommandToSwitchStatus(pur.id, newStatusID.ToString());
        }


        private void SendCommandToSwitchStatus(int id, string newStatusID)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE Purchases SET stageID = '");
            sb.Append(newStatusID);
            sb.Append("' WHERE id = '");
            sb.Append(id);
            sb.Append("'");

            LogManager.LogPurchaseUpdate(0, id, sb.ToString());
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
