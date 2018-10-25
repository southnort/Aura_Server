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
using System.Runtime.InteropServices;
using System.Windows.Forms;


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

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();

        private static bool showWindow = false;

        static void Main()
        {           
            try
            {
                StartIcon();
                StartDataBases();
                StartNetwork();
                StartTimers();

                Console.WriteLine("Server starting successfully. Version - " +
                    System.Windows.Forms.Application.ProductVersion);

                ShowForms();

                //при сворачивании в трей без этого, программа завершает работу
                Application.Run();
            }
            catch (Exception ex)
            {
                ShowWindow(GetConsoleWindow(), 1);
                Console.WriteLine("##############ERROR:\n");
                Console.WriteLine(ex.ToString());
                Console.Read();

            }
            
        }

        private static void StartIcon()
        {
            var icon = new NotifyIcon();
            icon.Icon = new System.Drawing.Icon("Icon.ico");
            icon.Visible = true;
            icon.DoubleClick += new EventHandler(Icon_DoubleClick);
            icon.Text = "Aura Server Console";
           
            ShowWindow(GetConsoleWindow(), 0);
        }

        private static void Icon_DoubleClick(object sender, EventArgs e)
        {
            showWindow = !showWindow;
            ShowWindow(GetConsoleWindow(), showWindow ? 0 : 1);

        }         

        private static void StartDataBases()
        {
            //настраиваем соединения с БД            
            
            
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
            //включаем сетевое соединение
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

        private static void StartTimers()
        {
            //запуск таймеров, срабатывающих в определенное время
            //например, закупки автоматически меняют статус
            System.Timers.Timer statusSwitchTimer = new System.Timers.Timer();
            statusSwitchTimer.Interval = 3600000;
            statusSwitchTimer.AutoReset = true;
            statusSwitchTimer.Elapsed += Timer_Elapsed;
            statusSwitchTimer.Enabled = true;

            System.Timers.Timer backupTimer = new System.Timers.Timer();
            backupTimer.Interval = 10800000;
            backupTimer.AutoReset = true;
            backupTimer.Elapsed += BackupTimer_Elapsed;
            backupTimer.Enabled = true;

            StatusSwitchManagerTick();
            CreateBackup();
        }

        private static void BackupTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            CreateBackup();

        }

        private static void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            StatusSwitchManagerTick();

        }

        private static void StatusSwitchManagerTick()
        {           
            StatusSwitchManager manager = new StatusSwitchManager();
            manager.Tick();
            
        }

       

        private static void ShowForms()
        {
            //открываем формы 

            SqlCommandsConsoleForm sqlCommandsConsoleForm = new SqlCommandsConsoleForm();
            sqlCommandsConsoleForm.ShowDialog();

        }

        

        private static void TestMethod()
        {


        }

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
            //создание бэкапа базы данных
            Thread backupThread = new Thread(new ThreadStart(BackupMethod));
            backupThread.Start();
            
        }

        private static void BackupMethod()
        {
            string directoryPath = AppDomain.CurrentDomain.BaseDirectory + "\\Backups\\";
            string postscript = "_" + DateTime.Now.ToString("dd.MM.yyy-HH.mm");


            string newDBFileName = directoryPath + dbFileName + postscript;
            string newDBForLogsFileName = directoryPath + dbForLogsFileName + postscript;

            File.Copy(dbFileName, newDBFileName);
            File.Copy(dbForLogsFileName, newDBForLogsFileName);

            BackupFilesSender backupFilesSender = new BackupFilesSender();
            backupFilesSender.SendMail(newDBFileName, newDBForLogsFileName);

            Console.WriteLine("\nBackup\n");

        }

    }   

}




//private static void LoadOrganisations()
//{
//    ListOfOrganistations listOfOrganisations44 = new ListOfOrganistations();
//    ListOfOrganistations listOfOrganisations223 = new ListOfOrganistations();

//    var table1 = LoadTable("Журнал регистрации договоров 44-ФЗ 2018 год.xlsx");
//    var table2 = LoadTable("Журнал регистрации договоров 223-ФЗ 2018 год.xlsx");

//    var table3 = LoadTable("Журнал регистрации 1 раз 44-фз 2018 год.xlsx");
//    var table4 = LoadTable("Журнал регистрации 1 раз 223-фз 2018 год.xlsx");

//    var table5 = LoadTable("Список предприятий c телефонами мупы.xlsx");
//    var table6 = LoadTable("Список предприятий c тел. 223-ФЗ на 14.06.2018.xlsx");


//    foreach (var str in table1)
//    {
//        Organisation org = new Organisation();

//        org.name = str[1];
//        org.contactName = str[2];
//        org.contractStart = GetDate(str[4]);
//        org.contractEnd = GetDate(str[5]);

//        switch (str[6])
//        {
//            case "оригинал": org.originalID = 1; break;
//            case "оригинал в эл. виде": org.originalID = 3; break;

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
//            case "оригинал": org.originalID = 1; break;
//            case "подписан ЭЦП": org.originalID = 3; break;
//            case "нет оригинала": org.originalID = 2; break;
//            case "без договора": org.originalID = 4; break;

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
//            case "оригинал": org.originalID = 1; break;
//            case "нет": org.originalID = 2; break;

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
//            case "оригинал": org.originalID = 1; break;
//            case "подписан ЭЦП": org.originalID = 3; break;
//            case "нет оригинала": org.originalID = 2; break;
//            case "без договора": org.originalID = 4; break;

//            default: org.originalID = 0; break;

//        }

//        org.inn = str[5];
//        org.contactName = str[6];
//        org.comments = "Акт: " + str[7];

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


//public class ListOfOrganistations : List<Organisation>
//{

//    public Organisation FindOrganisation(string inn, string name)
//    {
//        foreach (var org in this)
//        {
//            if (org.name == name || org.inn == inn)
//                return org;
//        }

//        return new Organisation();
//    }


//}
