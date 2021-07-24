using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PenaltyCalculation.Models
{
    public class CalculationModel
    {
        [MinLength(0)]
        [MaxLength(100)]
        public string checkinDate { get; set; }
        [MinLength(0)]
        [MaxLength(100)]
        public string checkOutDate { get; set; }
        [MinLength(0)]
        [MaxLength(50)]
        public string countries { get; set; }
        public List<string> holidays { get; set; }
        public List<string> weekend { get; set; }
    }
}
