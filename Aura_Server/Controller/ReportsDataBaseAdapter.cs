using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aura.Model;

namespace Aura_Server.Controller
{
    public class ReportsDataBaseAdapter : DataBaseAdapter
    {
        //класс для зваимодействия с таблицей "Reports" в БД
        public ReportsDataBaseAdapter(DataBaseManager manager) : base(manager)
        {

        }

        public List<Report> GetAllReports()
        {
            var result = new List<Report>();
            var table = GetData("SELECT * FROM Reports");

            for (int i = 0; i < table.Rows.Count; i++)
            {
                Report report = new Report(table.Rows[i]);
                result.Add(report);
            }

            return result;

        }

        public void UpdateReport(string sqlCommand, int reportID, int tryingUser)
        {
            ExecuteCommand(sqlCommand);

            LogManager.LogReportUpdate(tryingUser, reportID, sqlCommand);

        }


    }

}
