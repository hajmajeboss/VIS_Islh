using Backend.TableDataGateways;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Models
{
    public class Dilec : Model
    {
        public string Kod { get; set; }
        public string IdOddeleni { get; set; }

        private Oddeleni _odd;
        public Oddeleni Oddeleni { set { _odd = value; IdOddeleni = value.Id; } }

        public Oddeleni GetOddeleni(ITableDataGateway gw)
        {
            Oddeleni odd = (Oddeleni)gw.SelectOne(IdOddeleni);
            return odd;
        }
    }
}
