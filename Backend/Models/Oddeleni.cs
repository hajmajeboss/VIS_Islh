using Backend.TableDataGateways;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Models
{
    public class Oddeleni : Model
    {
        public string Kod { get; set; }
        public string IdLesniHospodarskyCelek { get; set; }

        private LesniHospodarskyCelek _lhc;
        public LesniHospodarskyCelek LesniHospodarskyCelek { set { _lhc = value; IdLesniHospodarskyCelek = value.Id; } }

        public LesniHospodarskyCelek GetLesniHospodarskyCelek(ITableDataGateway gw)
        {
            LesniHospodarskyCelek lhc = (LesniHospodarskyCelek)gw.SelectOne(IdLesniHospodarskyCelek);
            return lhc;
        }
    }
}
