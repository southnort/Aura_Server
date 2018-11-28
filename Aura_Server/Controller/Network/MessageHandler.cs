using System;
using System.Collections.Generic;
using System.Text;
using Aura.Model;
using System.Data;

using System.IO;

namespace Aura_Server.Controller.Network
{

    partial class MessageHandler : MessageHandlerBase
    {
        private ServerObject server;
        protected internal MessageHandler(ServerObject servObj)
        {
            server = servObj;
        }

        protected override void HandleMessage(List<string> message)
        {
            //обработать запрос, не требующий ответа      
            switch (message[2])
            {
                case "USER": ReceiveUser(message); break;
                case "NEWPURCHASE": ReceiveNewPurchase(message); break;
                case "UPDATEPURCHASE": ReceiveUpdatePurchase(message); break;
                case "DELETEPURCHASE": DeletePurchase(message); break;

                case "NEWORGANISATION": ReceiveNewOrganisation(message); break;
                case "UPDATEORGANISATION": ReveiveUpdateOrganisation(message); break;
                case "DELETEORGANISATION": DeleteOrganisation(message); break;
                case "UPDATEREPORT": UpdateReport(message); break;

                case "CHECKALLREPORTS": CheckAllReports(message); break;
                case "UNCHECKALLREPORTS": UncheckAllReports(message); break;
                case "CHANGEPASSWORD": ChangePassword(message); break;

                case "EXECUTECOMMAND": ExecuteCommand(message); break;

                case "SWITCHPROTOCOLSTATUSOFPURCHASE": SwitchStatusOfPurchase(message); break;
                case "CHANGEBIDSCOUNTINPURCHASE": ChangeCountOfBidsInPurchase(message); break;

                default: Console.WriteLine(ToString() + " invalid command " + message[2]); break;
            }

        }

        protected override void HandleRequest(List<string> message, string connectionID)
        {
            //обработать запрос, требующий ответа
            string response = "";

            switch (message[2])
            {
                case "LOGIN": response = TryLogin(message); break;


                default: response = "ERROR#No such command " + message[1]; break;

            }

            server.SendMessage(PrepareString(response), connectionID);

        }

        protected override void ReceiveObject(List<string> message, string connectionID)
        {
            //получить объект от клиента
            switch (message[2])
            {

                default: Console.WriteLine(ToString() + " invalid command " + message[2]); break;
            }
        }

        protected override void SendObject(List<string> message, string connectionID)
        {
            //клиент запрашивает объект
            switch (message[2])
            {
                case ("USERNAMES"): server.SendObject(CreateUserNames(), connectionID); break;
                case ("ALLPURCHASES"): server.SendObject(CreatePurchases(), connectionID); break;
                case ("ALLUSERS"): server.SendObject(GetAllUsers(), connectionID); break;
                case ("ALLORGANISATIONS"): server.SendObject(GetAllOrganisations(), connectionID); break;

                case ("GETUSER"): server.SendObject(GetUser(message), connectionID); break;
                case ("GETPURCHASE"): server.SendObject(GetPurchase(message), connectionID); break;
                case ("GETORGANISATION"): server.SendObject(GetOrganisation(message), connectionID); break;

                case ("GETFILTEREDORGANISATIONS"):
                    server.SendObject(GetFilteredOrganisations(message), connectionID); break;
                case ("GETREESTR"): server.SendObject(GetReestr(message), connectionID); break;

                case ("ALLREPORTS"): server.SendObject(GetAllReports(), connectionID); break;

                case ("GETDATATABLE"): server.SendObject(GetDataTable(message), connectionID); break;

                case ("GETITEM"): server.SendObject(GetSingleObject(message), connectionID); break;

                case ("GETLOGS"): server.SendObject(GetLogs(message), connectionID); break;

                default:
                    {
                        server.SendObject(null, connectionID);
                        Console.WriteLine(ToString() + " invalid command " + message[2]);
                    }
                    break;

            }

        }

        protected override void SendFile(List<string> message, string connectionID)
        {
            switch (message[2])
            {
                case ("GETXLFILE"):
                    {
                        string response;
                        string filePath;

                        try
                        {
                            filePath = GetExcelFile(message);
                            response = "Файл успешно создан";
                        }
                        catch (Exception ex)
                        {
                            filePath = "ERROR";
                            response = ex.Message;

                        }

                        server.SendFile(response, filePath, connectionID);

                    }
                    break;

                default:
                    {
                        server.SendObject(null, connectionID);
                        Console.WriteLine(ToString() + " invalid command " + message[2]);
                    }
                    break;
            }


        }






        private string TryLogin(List<string> str)
        {
            int id = Program.usersDataBase.CheckLoginAndPassword(str[3], str[4]);
            if (id == -1)
            {
                return "LOGINFAILED";
            }

            else
            {
                StringBuilder sb = new StringBuilder();
                var user = Program.usersDataBase.GetUser(id);

                sb.Append("LOGINSUCCESS#");
                sb.Append(user.name + "#");
                sb.Append(user.roleID + "#");
                sb.Append(user.ID + "#");
                sb.Append(user.login + "#");

                return sb.ToString();

            }

        }

        private void ChangePassword(List<string> str)
        {
            Program.usersDataBase.ChangePassword(str[3], str[4]);
        }


        private Dictionary<string, string> CreateUserNames()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            var table = Program.usersDataBase.GetUsersInTable();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                string id = table.Rows[i][0].ToString();
                string name = table.Rows[i][3].ToString();

                result.Add(id, name);
            }
            Console.WriteLine(result.Count);
            return result;

        }

        private List<User> GetAllUsers()
        {
            return Program.usersDataBase.GetAllUsers();
        }


        private List<Purchase> CreatePurchases()
        {
            return Program.purchasesDataBase.GetAllPurchases();

        }

        private List<Purchase> GetReestr(List<string> str)
        {
            Console.WriteLine("++++++++++\n" + str[3]);
            return Program.purchasesDataBase.GetReestr(str[3]);
        }


        private List<Organisation> GetAllOrganisations()
        {
            return Program.organisationsDataBase.GetOrganisations();
        }

        private List<Organisation> GetFilteredOrganisations(List<string> str)
        {
            return Program.organisationsDataBase.GetFilteredOrganisations(str[3]);
        }


        private void ReceiveUser(List<string> message)
        {
            //от клиента получены данные юзера для создания или изменения
            int clientID = int.Parse(message[1]);

            User user = new User();
            user.ID = int.Parse(message[3]);
            user.name = message[4];
            user.login = message[5];
            user.password = message[6];
            user.roleID = int.Parse(message[7]);

            Program.usersDataBase.AddUser(user, clientID);

        }

        private void ReceiveNewPurchase(List<string> message)
        {
            int clientID = int.Parse(message[1]);

            Purchase newPurchase = Program.purchasesDataBase
                .AddNewPurchase(message[3], clientID);

        }

        private void ReceiveUpdatePurchase(List<string> message)
        {
            int clientID = int.Parse(message[1]);
            Purchase newPurchase = Program.purchasesDataBase
                .UpdatePurchase(message[3], clientID);


            int startIndex = message[3].IndexOf("WHERE ID = ");
            string result = message[3].Substring(startIndex).Replace("WHERE ID = ", "");

        }

        private void DeletePurchase(List<string> message)
        {
            int clientID = int.Parse(message[1]);
            int purID = int.Parse(message[3]);
            Program.purchasesDataBase.DeletePurchase(purID, clientID);
        }


        private void ReceiveNewOrganisation(List<string> message)
        {
            int clietnID = int.Parse(message[1]);

            Organisation org = Program.organisationsDataBase
                .AddNewOrganisation(message[3], clietnID);

        }

        private void ReveiveUpdateOrganisation(List<string> message)
        {
            int clientID = int.Parse(message[1]);
            Organisation org = Program.organisationsDataBase
                .UpdateOrganisation(message[3], clientID);

            int startIndex = message[3].IndexOf("WHERE ID = ");
            string result = message[3].Substring(startIndex).Replace("WHERE ID = ", "");

        }


        private User GetUser(List<string> message)
        {
            //отослать клиенту запрашиваемого юзера
            int id = int.Parse(message[3]);
            return Program.usersDataBase.GetUser(id);

        }

        private Purchase GetPurchase(List<string> message)
        {
            //отослать клиенту запрашиваемую закупку
            int id = int.Parse(message[3]);
            return Program.purchasesDataBase.GetPurchase(id);

        }

        private Organisation GetOrganisation(List<string> message)
        {
            //отослать клиенту запрашиваемую организацию
            int id = int.Parse(message[3]);
            return Program.organisationsDataBase.GetOrganisation(id);

        }

        private void DeleteOrganisation(List<string> message)
        {
            int clientID = int.Parse(message[1]);
            int orgId = int.Parse(message[3]);
            Program.organisationsDataBase.DeleteOrganisation(orgId, clientID);
        }


        private ReportsList GetAllReports()
        {
            return Program.reportsDataBaseAdapter.GetAllReports();
        }

        private void UpdateReport(List<string> message)
        {
            try
            {
                int clientID = int.Parse(message[1]);
                int reportID = int.Parse(message[4]);



                Program.reportsDataBaseAdapter.UpdateReport(message[3], reportID, clientID);
            }

            catch
            {
                Console.WriteLine("######################");
                foreach (var str in message)
                {
                    Console.WriteLine("String : " + str);
                }

                Console.Read();
            }
        }

        private DataTable GetDataTable(List<string> message)
        {
            if (message[3].ToLower().Contains(" from logs") || message[3].ToLower().Contains("update logs "))
            {
                var table = LogManager.Instance.GetTable(message[3]);
                return table;
            }

            else
            {
                var table = Program.dataBase.GetTable(message[3]);
                return table;
            }
        }

        private void ExecuteCommand(List<string> message)
        {
            Program.dataBase.ExecuteCommand(message[3]);
        }

        private object GetSingleObject(List<string> message)
        {
            return Program.dataBase.GetValue(message[3]);
        }


        private void CheckAllReports(List<string> message)
        {
            int clientID = int.Parse(message[1]);
            Program.reportsDataBaseAdapter.CheckAllReports(message[3], clientID);
        }

        private void UncheckAllReports(List<string> message)
        {
            int clientID = int.Parse(message[1]);
            Program.reportsDataBaseAdapter.UncheckAllReports(message[3], clientID);
        }

        private DataTable GetLogs(List<string> message)
        {
            return LogManager.Instance.GetTable(message[3]);
        }

        private void SwitchStatusOfPurchase(List<string> message)
        {
            int clientID = int.Parse(message[1]);

            Program.purchasesDataBase.SwitchProtocolStatusOfPurchase(message[3],
                message[4], clientID);

        }

        private void ChangeCountOfBidsInPurchase(List<string> message)
        {
            int clientID = int.Parse(message[1]);

            Program.purchasesDataBase.ChangeBidsCountInPurchase(message[3],
                message[4], clientID);

        }


        private string GetExcelFile(List<string> message)
        {
            //обрабатывает запрос, создаёт файл на диске и возвращает его местонахождение


            return Program.dataBase.CreateExcelFile(message[3]);
            //Program.dataBase.CreateExcelFile(message[3]);

            //return "testFIle.xls";
        }
    }



}
