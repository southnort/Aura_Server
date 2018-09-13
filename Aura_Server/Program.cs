using Aura.Model;
using Aura_Server.Controller;
using Aura_Server.Controller.Network;
using Aura_Server.Excel;
using Aura_Server.Model;
using Aura_Server.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;


namespace Aura_Server
{
    class Program
    {
        public static DataBaseManager dataBase;

        public static UsersTableAdapter usersDataBase;
        public static PurchasesTableAdapter purchasesDataBase;
        public static OrganisationsDataBaseAdapter organisationsDataBase;
        public static ReportsDataBaseAdapter reportsDataBaseAdapter;

        private static string dbForLogsFileName = "AuraDataBase_ForLogs.sqlite";
        private static string dbFileName = "AuraDataBase.sqlite";



        static void Main()
        {
            StartDataBases();
            StartNetwork();
            //  LoadOrganisations();
            //  TestMethod();
            Console.WriteLine("Server starting successfully");

            ShowForms();


            CreateBackup();
        }

        private static void StartDataBases()
        {
            //����������� ���������� � ��            
            
            
            DataBaseCreator creator = new DataBaseCreator();
            creator.CreateDataBaseForLogs(dbForLogsFileName);
            creator.CreateMainDataBase(dbFileName);
            creator.UpdateTables(dbFileName);
            creator = null;

            LogManager.Instance.InitializeLogManager(dbForLogsFileName);

            dataBase = new DataBaseManager();
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

            //LoginWindow loginWindow = new LoginWindow(usersDataBase);
            //loginWindow.ShowDialog();
           
            SqlCommandsConsoleForm sqlCommandsConsoleForm = new SqlCommandsConsoleForm();
            sqlCommandsConsoleForm.ShowDialog();

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
        //        org.contractStart = GetDate(str[4]);
        //        org.contractEnd = GetDate(str[5]);

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
        //        org.contractStart = GetDate(str[4]);
        //        org.contractEnd = GetDate(str[5]);

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
        //        org.contractStart = GetDate(str[4]);
        //        org.contractEnd = GetDate(str[5]);

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
        //        Organisation org = listOfOrganisations223.FindOrganisation(str[2], str[1]);

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
        //        organisationsDataBase.AddNewOrganisation(org, -1);
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


        private static DateTime GetDate(string dateString)
        {
            if (dateString != string.Empty)
            {
                try
                {
                   return DateTime.Parse(dateString);

                }
                catch
                {
                    Console.WriteLine("What date is it: \"" +
                        dateString+"\"?");
                    string tempo = Console.ReadLine();
                    if (tempo == string.Empty)
                        return DateTime.MinValue;
                    else
                    return DateTime.Parse(tempo);

                }
            }

            else
            {
                return DateTime.MinValue;
            }
        }


        public static void CreateBackup()
        {
            //�������� ������ ���� ������
            string directoryPath = AppDomain.CurrentDomain.BaseDirectory + "\\Backups\\";
            string postscript ="_" + DateTime.Now.ToString("dd.MM.yyy-HH.mm");
             

            string newDBFileName = directoryPath + dbFileName + postscript;
            string newDBForLogsFileName = directoryPath + dbForLogsFileName + postscript;

            Console.WriteLine(newDBFileName);
            Console.WriteLine(newDBForLogsFileName);

            File.Copy(dbFileName, newDBFileName);
            File.Copy(dbForLogsFileName, newDBForLogsFileName);

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
