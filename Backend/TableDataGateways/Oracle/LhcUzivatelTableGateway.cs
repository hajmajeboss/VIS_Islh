﻿using Backend.Models;
using Backend.TableDataGateways.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.TableDataGateways.Oracle
{
    public class LhcUzivatelTableGateway : OracleTableDataGateway, ILhcUzivatelTableGateway
    {
        public override bool Delete(Model obj)
        {
            throw new NotImplementedException();
        }

        public override bool Insert(Model obj)
        {
            throw new NotImplementedException();
        }

        public override List<Model> SelectAll()
        {
            throw new NotImplementedException();
        }

        public override Model SelectOne(string id)
        {
            throw new NotImplementedException();
        }

        public override bool Update(Model obj)
        {
            throw new NotImplementedException();
        }
    }
}
