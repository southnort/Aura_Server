using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Aura.Model;
using Aura_Server.Model;

namespace Aura_Server.Controller
{
    public class OrganisationsDataBaseAdapter : DataBaseAdapter
    {
        //класс для взаимодействия с таблицей "Organisations" в БД
        public OrganisationsDataBaseAdapter(DataBaseManager manager) : base(manager)
        {
        }

        public string AddNewOrganisation(Organisation org, int tryingUserID)
        {
            //создание и добавление новой организации в БД
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO Organisations ('name', 'inn', 'phoneNumber', 'contactName', 'email', 'originalID', 'contractNumber', 'contractStart', 'contractEnd', 'comments', 'contractCondition', 'law', 'contractType') values ('");
            sb.Append(org.name);
            sb.Append("', '");
            sb.Append(org.inn);
            sb.Append("', '");
            sb.Append(org.phoneNumber);
            sb.Append("', '");
            sb.Append(org.contactName);
            sb.Append("', '");
            sb.Append(org.email);
            sb.Append("', '");
            sb.Append(org.originalID);
            sb.Append("', '");
            sb.Append(org.contractNumber);
            sb.Append("', '");
            sb.Append(org.contractStart);
            sb.Append("', '");
            sb.Append(org.contractEnd);
            sb.Append("', '");
            sb.Append(org.comments);
            sb.Append("', '");
            sb.Append(org.contractCondition);
            sb.Append("', '");
            sb.Append(org.law);
            sb.Append("', '");
            sb.Append(org.contractType);
            sb.Append("')");

            try
            {
                AddNewOrganisation(sb.ToString(), tryingUserID);
                return "Success";
            }

            catch (Exception ex)
            {
                throw (new Exception(ex.ToString() + "\n"
                    + sb.ToString()));
            }


        }

        public Organisation AddNewOrganisation(string sqlCommand, int tryingUserID)
        {
            try
            {
                //добавляем организацию через SQL запрос
                string result = ExecuteCommand(sqlCommand);

                //возвращаем только что добавленную организацию
                var table = dataBase.GetTable("SELECT * FROM Organisations WHERE ID=last_insert_rowid()");
                var row = table.Rows[0];

                Organisation newOrg = new Organisation(row);
                LogManager.LogOrganisationAdding(tryingUserID, newOrg.id, sqlCommand);
                return newOrg;

            }

            catch (Exception ex)
            {
                throw (new Exception(ex.ToString() + "\n"
                    + sqlCommand));
            }
        }

        public Organisation UpdateOrganisation(string sqlCommand, int tryingUserID)
        {
            try
            {
                //поиск в строке ID меняемой организации
                int startIndex = sqlCommand.IndexOf("WHERE ID = ");
                string orgIDstr = sqlCommand.Substring(startIndex).Replace("WHERE ID = ", "");
                int orgID = int.Parse(orgIDstr);

                LogManager.LogOrganisationUpdate(tryingUserID, orgID, sqlCommand);
                ExecuteCommand(sqlCommand);
                return GetOrganisation(orgID);

            }

            catch (Exception ex)
            {
                throw (new Exception(ex.ToString() + "\n"
                    + sqlCommand));
            }
        }

        public DataTable GetAllOrganisations()
        {
            //вернуть все организации в виде таблицы
            return GetData("SELECT * FROM Organisations");
        }

        public List<Organisation> GetOrganisations()
        {
            //вернуть все организации в виде List
            var result = new List<Organisation>();
            var table = GetAllOrganisations();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                Organisation org = new Organisation(table.Rows[i]);
                result.Add(org);

            }

            return result;
            
        }

        public List<Organisation> GetFilteredOrganisations(string sqlCommand)
        {
            var result = new List<Organisation>();
            var table = GetData(sqlCommand);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                Organisation org = new Organisation(table.Rows[i]);
                result.Add(org);
            }

            return result;

        }

        public Organisation GetOrganisation(int id)
        {
            var table = dataBase.GetTable("SELECT * FROM Organisations WHERE ID= " + id);
            var row = table.Rows[0];
            return new Organisation(row);

        }

        public void DeleteOrganisation(int organisationId, int tryingUserID )
        {
            //удалить организацию из БД
            string command = "DELETE FROM Organisations WHERE id = '" + organisationId + "'";
            LogManager.LogOrganisationUpdate(tryingUserID, organisationId, command);
            ExecuteCommand(command);

        }


    }



}
