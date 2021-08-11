using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PenaltyCalculation.Models
{
    public class AccessLevelModel
    {
        [Key]
        public string Username { get; set; }
        public string AccessLevel { get; set; }
        public string UserRole { get; set; }
    }
}
