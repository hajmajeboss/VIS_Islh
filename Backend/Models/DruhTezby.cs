using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Models
{
    public class DruhTezby : Model
    {
        public string Popis { get; set; }
        public string Kod { get; set; }
        public string Poznamka { get; set; }
    }
}
