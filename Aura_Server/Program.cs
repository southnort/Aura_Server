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

        static void Main()
        {
            StartDataBases();
            StartNetwork();
            LoadOrganisations();
            //  TestMethod();

            ShowForms();

            Console.WriteLine("Server starting successfully");

        }

        private static void StartDataBases()
        {
            //настраиваем соединения с БД            
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

        private static void ShowForms()
        {
            //открываем формы 

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


        private static void LoadOrganisations()
        {
            ListOfOrganistations listOfOrganisations44 = new ListOfOrganistations();
            ListOfOrganistations listOfOrganisations223 = new ListOfOrganistations();

            var table1 = LoadTable("Журнал регистрации договоров 44-ФЗ 2018 год.xlsx");
            var table2 = LoadTable("Журнал регистрации договоров 223-ФЗ 2018 год.xlsx");

            var table3 = LoadTable("Журнал регистрации 1 раз 44-фз 2018 год.xlsx");
            var table4 = LoadTable("Журнал регистрации 1 раз 223-фз 2018 год.xlsx");

            var table5 = LoadTable("Список предприятий c телефонами мупы11.xlsx");
            var table6 = LoadTable("Список предприятий c тел. 223-ФЗ на 14.06.2018.xlsx");

            int number = 0;
            foreach (var str in table1)
            {
                
                if (IsNotEmpty(str))
                {
                    Organisation org = new Organisation();
                    org.name = str[0];

                    //string regexPattern = "(.*)( от )";
                    //string result = Regex.Match(str[1], regexPattern).Value.Replace(" от ","");
                    //org.contractNumber = result;

                    //regexPattern = ("( от )(.*)");
                    //result = Regex.Match(str[1],regexPattern).Value.Replace(" от ", "");
                    //org.contractStart = result;

                    org.contractNumber = str[1];
                    org.contractStart = str[3];
                    try
                    {
                        org.contractEnd = str[4];
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(str.Count + " " + number);
                    }

                    switch (str[5])
                    {
                        case "оригинал": org.originalID = 1; break;
                        case "оригинал в эл. виде": org.originalID = 3; break;
                        default:
                            {
                                Console.WriteLine(org.name + " #" + str[5] + "#");
                                org.originalID = Console.Read();

                            }
                            break;

                    }

                    org.inn = str[6];
                    org.comments = str[7];

                    org.contractCondition = 1;
                    org.law = 1;
                    org.contractType = 1;

                    listOfOrganisations44.Add(org);
                    number++;
                }

            }

            foreach (var str in table2)
            {
                if (IsNotEmpty(str))
                {
                    Organisation org = new Organisation();

                    org.name = str[0];
                    org.contractNumber = str[1];
                    org.contractStart = str[3];
                    org.contractEnd = str[4];

                    switch (str[5])
                    {
                        case "оригинал": org.originalID = 1; break;
                        case "подписан ЭЦП": org.originalID = 3; break;
                        case "нет оригинала": org.originalID = 2; break;
                        default:
                            {
                                Console.WriteLine(org.name + " #" + str[5] + "#");
                                org.originalID = Console.Read();

                            }
                            break;

                    }

                    org.inn = str[6];
                    org.comments = str[7];

                    org.contractCondition = 1;
                    org.law = 2;
                    org.contractType = 1;

                    listOfOrganisations223.Add(org);

                }
            }

            foreach (var str in table3)
            {
                if (IsNotEmpty(str))
                {
                    Organisation org = new Organisation();
                    org.name = str[0];

                    org.contractNumber = str[1];
                    org.contractStart = str[3];
                    org.contractEnd = str[4];

                    switch (str[5])
                    {
                        case "оригинал": org.originalID = 1; break;
                        case "оригинал в эл. виде": org.originalID = 3; break;
                        default:
                            {
                                Console.WriteLine(org.name + " #" + str[5] + "#");
                                org.originalID = Console.Read();

                            }
                            break;

                    }

                    org.inn = str[6];
                    org.comments = str[7];

                    org.contractCondition = 1;
                    org.law = 1;
                    org.contractType = 2;

                    listOfOrganisations44.Add(org);

                }
            }

            foreach (var str in table4)
            {
                if (IsNotEmpty(str))
                {
                    Organisation org = new Organisation();

                    org.name = str[0];
                    org.contractNumber = str[1];

                    switch (str[3])
                    {
                        case "оригинал": org.originalID = 1; break;
                        case "подписан ЭЦП": org.originalID = 3; break;
                        case "нет оригинала": org.originalID = 2; break;
                        default:
                            {
                                Console.WriteLine(org.name + " #" + str[5] + "#");
                                org.originalID = Console.Read();

                            }
                            break;

                    }

                    org.inn = str[4];
                    org.contactName = str[5];
                   
                    org.comments = str[6];

                    org.contractCondition = 1;
                    org.law = 2;
                    org.contractType = 2;

                    listOfOrganisations223.Add(org);

                }
            }

            foreach (var str in table5)
            {
                if (IsNotEmpty(str))
                {
                    Organisation org = listOfOrganisations44.GetOrganisation(str[0]);
                    if (org == null)
                        org = listOfOrganisations44.GetOrganisation(str[1]);
                    if (org == null)
                    {
                        org = new Organisation();
                        listOfOrganisations44.Add(org);
                    }

                    if (org.name != str[0])
                    {
                        Console.WriteLine("#" + org.name + "# - #" + str[0] + "#");
                        if (Console.Read() == 1)
                            org.name = str[0];
                    }

                    if (org.inn == "")
                        org.inn = str[1];
                    else
                    {
                        if (org.inn != str[1])
                            Console.WriteLine("#" + org.name + "# - #" + str[1] + "#");
                        if (Console.Read() == 1)
                            org.inn = str[1];
                    }

                    org.phoneNumber = str[2];
                    org.contactName = str[3];
                    org.email = str[4];


                }
            }

            foreach (var str in table6)
            {
                if (IsNotEmpty(str))
                {
                    Organisation org = listOfOrganisations223.GetOrganisation(str[0]);
                    if (org == null)
                        org = listOfOrganisations223.GetOrganisation(str[1]);
                    if (org == null)
                    {
                        org = new Organisation();
                        listOfOrganisations223.Add(org);
                    }

                    if (org.name != str[0])
                    {
                        Console.WriteLine("#" + org.name + "# - #" + str[0] + "#");
                        if (Console.Read() == 1)
                            org.name = str[0];
                    }

                    if (org.inn == "")
                        org.inn = str[1];
                    else
                    {
                        if (org.inn != str[1])
                            Console.WriteLine("#" + org.name + "# - #" + str[1] + "#");
                        if (Console.Read() == 1)
                            org.inn = str[1];
                    }

                    org.phoneNumber = str[2];
                    org.contactName = str[3];
                    org.email = str[4];
                }
            }


            Console.WriteLine(listOfOrganisations44.Last().email);
            Console.WriteLine(listOfOrganisations223.Last().email);
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

    }

    public class ListOfOrganistations : List<Organisation>
    {
        public bool ContainsInn(string inn)
        {
            foreach (var org in this)
            {
                if (org.inn == inn)
                    return true;
            }

            return false;
        }
        
        public bool ContainsName(string name)
        {
            foreach (var org in this)
            {
                if (org.name == name)
                    return true;
            }

            return false;
        }

        public Organisation GetOrganisation(string nameOrInn)
        {
            foreach (var org in this)
            {
                if (org.name == nameOrInn)
                    return org;

                if (org.inn == nameOrInn)
                    return org;
            }

            return null;

        }


    }

}
