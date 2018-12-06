using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Models
{
    public class Drevina : Model
    {
        public string Popis { get; set; }
        public string Kod { get; set; }
        public double Hustota { get; set; }
        public string Poznamka { get; set; }
    }
}
