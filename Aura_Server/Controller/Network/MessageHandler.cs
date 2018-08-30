using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aura.Model;

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

                default: Console.WriteLine(ToString() + " invalid command " + message[1]); break;
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
                case ("GETREESTR"): server.SendObject(GetReestr(), connectionID); break;

                case ("ALLREPORTS"): server.SendObject(GetAllReports(), connectionID); break;

                default:
                    {
                        server.SendObject(null, connectionID);
                        Console.WriteLine(ToString() + " invalid command " + message[1]);
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
                sb.Append(user.ID);

                return sb.ToString();

            }

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
            return Program.purchasesDataBase.GetPurchases();

        }

        private List<Purchase> GetReestr()
        {
            return Program.purchasesDataBase.GetReestr();
        }
        

        private List<Organisation> GetAllOrganisations()
        {
            return Program.organisationsDataBase.GetOrganisations();
        }

        private List<Organisation> GetFilteredOrganisations(List<string>str)
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


        private List<Report> GetAllReports()
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
                    Console.WriteLine("String^ : " +str );
                }

                Console.Read();
            }
        }

    }


}
