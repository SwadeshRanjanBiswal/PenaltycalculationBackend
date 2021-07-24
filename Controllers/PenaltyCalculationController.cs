using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PenaltyCalculation.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using WebApplication1.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PenaltyCalculation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PenaltyCalculationController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        public PenaltyCalculationController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        // GET: api/<PenaltyCalculationController>
        [HttpGet]
        [Produces("application/json")]
        public ActionResult Get()
        {
            var result = from holiday in _dbContext.Countrywiseholiday
                         join weekend in _dbContext.Countrywiseweekend on
                         holiday.Country equals weekend.Country select new { Country = holiday.Country.Trim(),Holiday = holiday.Holidays.Trim(),
                             Weekend = weekend.Weekend.Trim()};

            return Ok(result);
        }
        [HttpPost]
        public int Post(CalculationModel calculationModel)
        {
            if (ModelState.IsValid)
            {
                DateTime checkInDt = DateTime.Parse(calculationModel.checkinDate);
                DateTime checkOutDt = DateTime.Parse(calculationModel.checkOutDate);
                dynamic weekend = calculationModel.weekend.Select(x => (DayOfWeek)Enum.Parse(typeof(DayOfWeek), x)).ToList();
                int dateDiff = GetWorkingDays(checkInDt,checkOutDt, weekend, calculationModel.holidays);
                return dateDiff;
            }
            else
                return 0;
        }
        private int GetWorkingDays(DateTime from, DateTime to, List<DayOfWeek> weekends,List<string> holidays)
        {
            var dayDifference = (int)to.Subtract(from).TotalDays;
            return Enumerable
                .Range(1, dayDifference)
                .Select(x => from.AddDays(x))
                .Count(x => !weekends.Contains(x.DayOfWeek) && !holidays.Contains(x.Date.ToString()));
        }
        // PUT api/<PenaltyCalculationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PenaltyCalculationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
