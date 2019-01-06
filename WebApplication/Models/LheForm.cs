using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class LheForm
    {
        [Required]
        public DateTime Datum { get; set; }

        [Required]
        [DisplayName("Množství")]
        public double Mnozstvi { get; set; }

        [Required]
        public double Plocha { get; set; }

        [Required]
        [DisplayName("Poznámka")]
        public string Poznamka { get; set; }

        [Required]
        public string Id { get; set; }
    }
}
