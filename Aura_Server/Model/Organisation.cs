using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aura_Server.Model
{
    class Organisation
    {
        //класс, описывающий организацию-заказчика

        public int id;
        public string name;         
        public string inn;          
        public string phoneNumber;  
        public string contactName;
        public string email;

        /// <summary>
        /// Наличие оригинала договора,
        /// 0 - не указано,
        /// 1 - оригинал,
        /// 2 - нет оригинала,
        /// 3 - подписан ЭЦП
        /// 4 - без договора,
        /// </summary>
        public int originalID;
        public string contractNumber;       //номер договора с заказчиком
        public string contractStart;        //начало действия договора
        public string contractEnd;          //окончание действия договора        
        public string comments;

        

    }
}
