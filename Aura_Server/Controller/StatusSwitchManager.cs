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
            foreach (var events in day.events)
            {

            }

        }

        private void HandlePurchase(


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
