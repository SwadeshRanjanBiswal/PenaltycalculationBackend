using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PenaltyCalculation.Models
{
    public class LoginModel
    {
        [MinLength(0)]
        [Key]
        public string Username { get; set; }
        [MinLength(0)]
        public string Password { get; set; }
    }
}
