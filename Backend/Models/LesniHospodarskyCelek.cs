using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Models
{
    public class LesniHospodarskyCelek : Model
    {
        public string Kod { get; set; }

        public override string ToString()
        {
            return Kod;
        }
    }

}
