using Backend.Models;
using Backend.TableDataGateways.Interfaces;
using Backend.TableDataGateways.StorageContexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.TableModules
{
    public class UzivatelTableModule
    {
        IStorageContext db;

        public UzivatelTableModule(IStorageContext db)
        {
            this.db = db;
        }

        public Uzivatel TrySignIn(Uzivatel uzivatel)
        {
            Uzivatel u = (Uzivatel)db.UzivatelTableGateway.SelectByName(uzivatel.Username);
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
 