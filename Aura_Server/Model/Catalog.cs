using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aura_Server.Model
{
   static public class Catalog
    {
        //класс-хранилище для списков
        public static List<string> purchasesNames = new List<string>()
        {
            "<не указано>",
            "Единственный поставщик",
            "Запрос котировок",
            "Электронный аукцион",

        };

        public static List<string> statusesNames = new List<string>()
        {
            "<не указано>",
            "Новый",
            "Проверка",
            "На доработку",
            "На публикацию",
            "Прием заявок",
            "Рассмотрение",
            "Заключение контракта",
            "Завершена",

        };

        public static List<string> organisationsNames = new List<string>()
        {
            "<не указано>",
            "Тестовый заказчик 1",
            "Тестовый заказчик 2",
            "Тестовый заказчик 3",

        };
    }
}
