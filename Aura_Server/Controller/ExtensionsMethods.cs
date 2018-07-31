using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;


namespace Aura_Server.Controller
{
   public static class ExtensionsMethods
    {
        //статический класс для расширящих методов
        public static DateTime ToDateTime(this string str)
        {
            try
            {
                return Convert.ToDateTime(str, CultureInfo.InvariantCulture);
            }

            catch (Exception ex)
            {
                LogManager.Log(-1,ex.Message);
                return DateTime.MinValue;
            }
          

        }
        
    }
}
