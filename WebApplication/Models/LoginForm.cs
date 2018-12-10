using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class LoginForm
    {
        [Required]
        [DisplayName("Uživatelské jméno")]
        public string Username { get; set; }
        [Required]
        [DisplayName("Heslo")]
        public string Password { get; set; }

    }
}

