using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class CountryWiseWeekend
    {
        [Key]
        public string Country { get; set; }
        public string Weekend { get; set; }
    }
    public class CountryWiseHoliday
    {
        [Key]
        public string Country { get; set; }
        public string Holidays { get; set; }
    }
}
