using Aura.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        private void UpdateReport(Report report)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("REPLACE INTO Reports (organisationID, commonPurchasesContractsReport, ");
            sb.Append("singleSupplierContractsReport, failedPurchasesContractsReport)");
            sb.Append(" VALUES ('");
            sb.Append(report.organisationID);
            sb.Append("', '");
            sb.Append(report.commonPurchasesContractsReport);
            sb.Append("', '");
            sb.Append(report.singleSupplierContractsReport);
            sb.Append("', '");
            sb.Append(report.failedPurchasesContractsReport);
            sb.Append("')");

            ExecuteCommand(sb.ToString());
        }

        public void CheckAllReports(string month, int tryingUser)
        {
            SetAllReports(month, true);
            LogManager.LogReportUpdate(tryingUser, -1, "CHECKALLREPORTS ON " + month);
        }

        public void UncheckAllReports(string month, int tryingUser)
        {
            SetAllReports(month, false);
            LogManager.LogReportUpdate(tryingUser, -1, "CHECKALLREPORTS OFF " + month);
        }

        private void SetAllReports(string month, bool adding)
        {
            var ids = GetData("SELECT id FROM Organisations WHERE law = 2 AND contractType = 1 ");
            var reports = GetAllReports();

            foreach (System.Data.DataRow row in ids.Rows)
            {
                int id = (int)(long)row[0];
                Report report = reports.SingleOrDefault(rep => rep.organisationID == id);
                if (report == null)
                    report = new Report();

                report.organisationID = id;

                if (adding)
                {
                    AddReportData(report, month);
                }

                else
                {
                    RemoveReportData(report, month);
                }

                UpdateReport(report);

            }
        }

        private void AddReportData(Report report, string month)
        {
            if (!report.commonPurchasesContractsReport.Contains(month))
                report.commonPurchasesContractsReport += month;

            if (!report.singleSupplierContractsReport.Contains(month))
                report.singleSupplierContractsReport += month;

            if (!report.failedPurchasesContractsReport.Contains(month))
                report.failedPurchasesContractsReport += month;

        }

        private void RemoveReportData(Report report, string month)
        {
            if (report.commonPurchasesContractsReport.Contains(month))
                report.commonPurchasesContractsReport =
                    report.commonPurchasesContractsReport.Replace(month, "");

            if (report.singleSupplierContractsReport.Contains(month))
                report.singleSupplierContractsReport =
                    report.singleSupplierContractsReport.Replace(month, "");

            if (report.failedPurchasesContractsReport.Contains(month))
                report.failedPurchasesContractsReport =
                    report.failedPurchasesContractsReport.Replace(month, "");
        }

    }

}
