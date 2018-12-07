using Backend.TableDataGateways;
using Backend.TableDataGateways.Interfaces;
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

        public LesniHospodarskyCelek GetLesniHospodarskyCelek(ILesniHospodarskyCelekTableGateway gw)
        {
            LesniHospodarskyCelek lhc = (LesniHospodarskyCelek)gw.SelectOne(IdLesniHospodarskyCelek);
            return lhc;
        }
    }
}
