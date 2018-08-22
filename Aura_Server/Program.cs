using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aura_Server.Model;
using Aura_Server.Controller;
using Aura_Server.View;
using System.Data;
using Aura_Server.Controller.Network;
using System.Threading;
using Aura_Server.Excel;

using Aura.Model;
using System.Text.RegularExpressions;

namespace Aura_Server
{
    class Program
    {
        public static UsersTableAdapter usersDataBase;
        public static PurchasesTableAdapter purchasesDataBase;
        public static OrganisationsDataBaseAdapter organisationsDataBase;
        public static ReportsDataBaseAdapter reportsDataBaseAdapter;

        static void Main()
        {
            StartDataBases();
            StartNetwork();
            //  LoadOrganisations();
            //  TestMethod();

            ShowForms();

            Console.WriteLine("Server starting successfully");

        }

        private static void StartDataBases()
        {
            //����������� ���������� � ��            
            string dbForLogsFileName = "AuraDataBase_ForLogs.sqlite";
            string dbFileName = "AuraDataBase.sqlite";

            DataBaseCreator creator = new DataBaseCreator();
            creator.CreateDataBaseForLogs(dbForLogsFileName);
            creator.CreateMainDataBase(dbFileName);
            creator.UpdateTables(dbFileName);
            creator = null;

            LogManager.Instance.InitializeLogManager(dbForLogsFileName);

            DataBaseManager dataBase = new DataBaseManager();
            dataBase.ConnectToDataBase(dbFileName);

            usersDataBase = new UsersTableAdapter(dataBase);
            purchasesDataBase = new PurchasesTableAdapter(dataBase);
            organisationsDataBase = new OrganisationsDataBaseAdapter(dataBase);
            reportsDataBaseAdapter = new ReportsDataBaseAdapter(dataBase);

            Console.WriteLine("Connection to DBs established successfully");
        }

        private static void StartNetwork()
        {
            //�������� ������� ����������
            ServerObject server;
            Thread listeningThread;
            try
            {
                server = new ServerObject();
                listeningThread = new Thread(new ThreadStart(server.Listen));
                listeningThread.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        private static void ShowForms()
        {
            //��������� ����� 

            LoginWindow loginWindow = new LoginWindow(usersDataBase);
            loginWindow.ShowDialog();

            //PurchasesCalendarForm calendarForm = new PurchasesCalendarForm(purchasesDataBase);
            //calendarForm.ShowDialog();

            //PurchasesDataBaseForm purchasesDataBaseForm = new PurchasesDataBaseForm(purchasesDataBase);
            //purchasesDataBaseForm.ShowDialog();

        }

        private static void TestMethod()
        {


        }


        //private static void LoadOrganisations()
        //{
        //    ListOfOrganistations listOfOrganisations44 = new ListOfOrganistations();
        //    ListOfOrganistations listOfOrganisations223 = new ListOfOrganistations();

        //    var table1 = LoadTable("������ ����������� ��������� 44-�� 2018 ���.xlsx");
        //    var table2 = LoadTable("������ ����������� ��������� 223-�� 2018 ���.xlsx");

        //    var table3 = LoadTable("������ ����������� 1 ��� 44-�� 2018 ���.xlsx");
        //    var table4 = LoadTable("������ ����������� 1 ��� 223-�� 2018 ���.xlsx");

        //    var table5 = LoadTable("������ ����������� c ���������� ����.xlsx");
        //    var table6 = LoadTable("������ ����������� c ���. 223-�� �� 14.06.2018.xlsx");


        //    foreach (var str in table1)
        //    {
        //        Organisation org = new Organisation();

        //        org.name = str[1];
        //        org.contactName = str[2];
        //        org.contractStart = str[4];
        //        org.contractEnd = str[5];

        //        switch (str[6])
        //        {
        //            case "��������": org.originalID = 1; break;
        //            case "�������� � ��. ����": org.originalID = 3; break;

        //            default: org.originalID = 0; break;

        //        }

        //        org.inn = str[7];
        //        org.comments = str[8];

        //        org.contractCondition = 1;

        //        org.law = 1;
        //        org.contractType = 1;

        //        listOfOrganisations44.Add(org);
        //    }

        //    foreach (var str in table2)
        //    {
        //        Organisation org = new Organisation();

        //        org.name = str[1];
        //        org.contactName = str[2];
        //        org.contractStart = str[4];
        //        org.contractEnd = str[5];

        //        switch (str[6])
        //        {
        //            case "��������": org.originalID = 1; break;
        //            case "�������� ���": org.originalID = 3; break;
        //            case "��� ���������": org.originalID = 2; break;
        //            case "��� ��������": org.originalID = 4; break;

        //            default: org.originalID = 0; break;

        //        }

        //        org.inn = str[7];
        //        org.comments = str[8];

        //        org.contractCondition = 1;

        //        org.law = 2;
        //        org.contractType = 1;

        //        listOfOrganisations223.Add(org);
        //    }

        //    foreach (var str in table3)
        //    {
        //        Organisation org = new Organisation();

        //        org.name = str[1];
        //        org.contactName = str[2];
        //        org.contractStart = str[4];
        //        org.contractEnd = str[5];

        //        switch (str[6])
        //        {
        //            case "��������": org.originalID = 1; break;
        //            case "���": org.originalID = 2; break;

        //            default: org.originalID = 0; break;

        //        }

        //        org.inn = str[7];
        //        org.comments = str[8];

        //        org.contractCondition = 1;

        //        org.law = 1;
        //        org.contractType = 2;

        //        listOfOrganisations44.Add(org);

        //    }

        //    foreach (var str in table4)
        //    {
        //        Organisation org = new Organisation();

        //        org.name = str[1];
        //        org.contactName = str[2];               

        //        switch (str[4])
        //        {
        //            case "��������": org.originalID = 1; break;
        //            case "�������� ���": org.originalID = 3; break;
        //            case "��� ���������": org.originalID = 2; break;
        //            case "��� ��������": org.originalID = 4; break;

        //            default: org.originalID = 0; break;

        //        }

        //        org.inn = str[5];
        //        org.contactName = str[6];
        //        org.comments = "���: " + str[7];                

        //        org.contractCondition = 1;

        //        org.law = 2;
        //        org.contractType = 2;

        //        listOfOrganisations223.Add(org);
        //    }


        //    foreach (var str in table5)
        //    {
        //        Organisation org = listOfOrganisations44.FindOrganisation(str[2], str[1]);

        //        org.name = str[1];
        //        org.inn = str[2];

        //        org.phoneNumber = str[3];
        //        org.contactName = str[4];
        //        org.email = str[5];

        //        if (!listOfOrganisations44.Contains(org))
        //        {
        //            listOfOrganisations44.Add(org);
        //        }
        //    }

        //    foreach (var str in table6)
        //    {
        //        Organisation org = listOfOrganisations223.FindOrganisation(str[2],str[1]);

        //        org.name = str[1];
        //        org.inn = str[2];
        //        org.phoneNumber = str[3];
        //        org.contactName = str[4];
        //        org.email = str[5];

        //        if (!listOfOrganisations223.Contains(org))
        //        {
        //            listOfOrganisations223.Add(org);
        //        }


        //    }


        //    foreach (var org in listOfOrganisations44)
        //    {
        //        organisationsDataBase.AddNewOrganisation(org,-1);
        //    }

        //    foreach (var org in listOfOrganisations223)
        //    {
        //        organisationsDataBase.AddNewOrganisation(org, -1);
        //    }

        //}

        private static List<List<string>> LoadTable(string fileName)
        {
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) +
                "/" + fileName;
            ExcelReader excel = new ExcelReader();


            return excel.GetFromFile(filePath);
        }

        private static bool IsNotEmpty(List<string> list)
        {
            foreach (var str in list)
            {
                if (str != null && str != string.Empty)
                    return true;
            }

            return false;
        }

    }

    public class ListOfOrganistations : List<Organisation>
    {

        public Organisation FindOrganisation(string inn, string name)
        {
            foreach (var org in this)
            {
                if (org.name == name || org.inn == inn)
                    return org;
            }

            return new Organisation();
        }
        

    }

}
