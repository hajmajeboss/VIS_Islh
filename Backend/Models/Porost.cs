using Backend.TableDataGateways;
using Backend.TableDataGateways.Interfaces;
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

        public Dilec GetDilec(IDilecTableGateway gw)
        {
            Dilec dil = (Dilec)gw.SelectOne(IdDilec);
            return dil;
        }

        public override string ToString()
        {
            return Kod;
        }
    }
}
