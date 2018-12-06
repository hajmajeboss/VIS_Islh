using Backend.TableDataGateways;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Models
{
    public class OrganizacniUroven2 : Model
    {
        public string Kod { get; set; }
        public string Popis { get; set; }
        public string Poznamka { get; set; }
        public string IdOrganizacniUroven1 { get; set; }

        private OrganizacniUroven1 _orgUr1;
        public OrganizacniUroven1 OrganizacniUroven1 { set { _orgUr1 = value;  IdOrganizacniUroven1 = value.Id; } }

        public OrganizacniUroven1 GetOrganizacniUroven1(ITableDataGateway gw)
        {
            OrganizacniUroven1 orgUr1 = (OrganizacniUroven1)gw.SelectOne(IdOrganizacniUroven1);
            return orgUr1;
        }
    }
}
