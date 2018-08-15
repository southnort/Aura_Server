using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aura_Server.Model
{
    class LogNode
    {
        //класс, используемый в системе логирования
        //описывает одно конкретное действие одного пользователя в один момент
        public int id;                  //ид закупки
        public int userID;              //ид юзера, совершившего действие
        public int purchaseID;          //ид закупки, которую изменили        
        public string message;          //описание действия
        public string logDateTime;      //дата и время, когда было совершено действие
        public int organisationID;      //ид изменяемой организации


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            sb.Append(logDateTime);
            sb.Append("]");
            if (userID > 0)
            {
                sb.Append(" UserID= ");
                sb.Append(userID);
            }
            if (purchaseID > 0)
            {
                sb.Append("\tPurchaseID= ");
                sb.Append(purchaseID);
            }
            if (organisationID > 0)
            {
                sb.Append("\tOrganistaionID= ");
                sb.Append(organisationID);
            }
            sb.Append("\t");
            sb.Append(message);

            return sb.ToString();

        }
    }
}
