using Backend.TableDataGateways.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Models
{
    public class Uzivatel : Model
    {
        public string Jmeno { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Role { get; set; }

        private List<LesniHospodarskyCelek> _lhcs;
        public List<LesniHospodarskyCelek> LesniHospodarskeCelky { set { _lhcs = value; } }

        public List<LesniHospodarskyCelek> GetLesniHospodarskyCelky(ILesniHospodarskyCelekTableGateway gw)
        {
            List<Model> lhcs = gw.SelectByUser(this);
            List<LesniHospodarskyCelek> ret = new List<LesniHospodarskyCelek>();

            foreach (Model lhc in lhcs)
            {
                ret.Add((LesniHospodarskyCelek)lhc);
            }

            return ret;
        }
    }
}
