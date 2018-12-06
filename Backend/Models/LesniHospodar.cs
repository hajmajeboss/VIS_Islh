using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Models
{
    public class LesniHospodar : Uzivatel
    {
        public List<LesniHospodarskyCelek> LesniHospodarskeCelky { get; set; }
    }
}
