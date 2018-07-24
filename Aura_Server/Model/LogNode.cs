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
        public int id;              
        public int userID;              //ид юзера, совершившего действие
        public int purchaseID;          //ид закупки, которую изменили
        public string message;          //описание действия
        public string logDateTime;      //дата и время, когда было совершено действие

    }
}
