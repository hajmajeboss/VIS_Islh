using Backend.TableDataGateways;
using Backend.TableDataGateways.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Models
{
    public class OrganizacniUroven3 : Model
    {
        public string Kod { get; set; }
        public string Popis { get; set; }
        public string Poznamka { get; set; }
        public string IdOrganizacniUroven2 { get; set; }

        private OrganizacniUroven2 _orgUr2;
        public OrganizacniUroven2 OrganizacniUroven2 { set { _orgUr2 = value; IdOrganizacniUroven2 = value.Id; } }

        public OrganizacniUroven2 GetOrganizacniUroven2(IOrganizacniUroven2TableGateway gw)
        {
            OrganizacniUroven2 orgUr2 = (OrganizacniUroven2)gw.SelectOne(IdOrganizacniUroven2);
            return orgUr2;
        }
    }
}
