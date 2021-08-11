using Microsoft.EntityFrameworkCore;
using PenaltyCalculation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        public DbSet<CountryWiseWeekend> Countrywiseweekend { get; set; }
        public DbSet<CountryWiseHoliday> Countrywiseholiday { get; set; }
        public DbSet<LoginModel> LoginModel { get; set; }
        public DbSet<AccessLevelModel> AccessLevelModel { get; set; }
    }
}
