using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura_Server.Model
{
    public class User
    {
        //класс, описывающий пользователя системы

                   
        public int ID;
        public string login;
        public string password;
        public string name;                 //отображаемое в системе имя
        public int roleID;                  //ИД роли пользователя в системе (Админ, размещающий, проверяющий итд)
        public DateTime dateOfCreation;     //дата создания юзера
        public DateTime dateOfLastEnter;    //дата последнего успешного входа


    }

}
