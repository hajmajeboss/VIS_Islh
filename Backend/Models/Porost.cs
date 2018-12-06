using Backend.TableDataGateways;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Models
{
    public class Porost : Model
    {
        public string Kod { get; set; }
        public string IdDilec { get; set; }

        private Dilec _dil;
        public Dilec Dilec { set { _dil = value; IdDilec = value.Id; } }

        public Dilec GetDilec(ITableDataGateway gw)
        {
            Dilec dil = (Dilec)gw.SelectOne(IdDilec);
            return dil;
        }
    }
}
