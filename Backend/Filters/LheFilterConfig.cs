using Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Filters
{
    public class LheFilterConfig
    {
        public Vykon Vykon { get; set; }
        public Podvykon Podvykon { get; set; }
        public DruhTezby DruhTezby { get; set; }
        public Drevina Drevina {get; set;}
    }
}
