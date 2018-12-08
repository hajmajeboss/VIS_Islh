using Backend.Models;
using Backend.TableDataGateways.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.TableModules
{
    public class UzivatelTableModule
    {
        IUzivatelTableGateway gateway;

        public UzivatelTableModule(IUzivatelTableGateway gw)
        {
            gateway = gw;
        }

        public Uzivatel TrySignIn(Uzivatel uzivatel)
        {
            Uzivatel u = (Uzivatel)gateway.SelectByName(uzivatel.Username);
            if (u != null && u.Password == uzivatel.Password)
            {
                return u;
            }
            else
            {
                return null;
            }
        }
    }
}
 