using Backend.TableDataGateways;
using Backend.TableDataGateways.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.TableModules
{
    public class VykonTableModule
    {
        private IVykonTableGateway gateway;
        public VykonTableModule(IVykonTableGateway gw)
        {
            gateway = gw;
        }
        
    }
}
