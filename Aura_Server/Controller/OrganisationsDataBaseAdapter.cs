using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public string AddOrganisation(Organisation org)
        {
            if (org.id < 1)
                return AddNewOrganisation(org);
            else
                return RefreshOrganisation(org);
        }

        private string AddNewOrganisation(Organisation org)
        {
            //создание и добавление новой организации в БД
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO Organisations ('name', 'inn', 'phoneNumber', 'contactName', 'email', 'originalID', 'contractNumber', 'contractStart', 'contractEnd', 'comments', 'contractCondition') values ('");
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
            sb.Append("')");
            return ExecuteCommand(sb.ToString());

        }

        private string RefreshOrganisation(Organisation org)
        {
            throw new NotImplementedException();
        }


    }



}
