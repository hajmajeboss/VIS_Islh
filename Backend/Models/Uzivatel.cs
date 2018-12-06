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
        public bool IsKontrolor { get; set; }
    }
}
