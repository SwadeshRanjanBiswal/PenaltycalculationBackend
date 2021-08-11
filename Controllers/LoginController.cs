using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PenaltyCalculation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TokenManagerHandler;
using WebApplication1.Models;

namespace PenaltyCalculation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;
        private readonly AppDbContext _appDbContext;
        public LoginController(ILogger<LoginController> logger,AppDbContext appDbContext)
        {
            _logger = logger;
            _appDbContext = appDbContext;
        }
        // GET: api/<LoginController>
        [HttpGet]
        [Produces("application/json")]
        public ActionResult Get()
        {
            var objlst = from loginmodel in _appDbContext.LoginModel select loginmodel;
            return Ok(objlst);
        }

        // GET api/<LoginController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LoginController>
        [HttpPost]
        public ResponseVM Post([FromBody] LoginModel loginModel)
        {
            var objlst = _appDbContext.LoginModel.Select(x => x.Username == loginModel.Username);
            if (objlst != null)
                return new ResponseVM { Status = "Inactive", Message = "User Inactive." };
            else
                return new ResponseVM { Status = "Success", Message = TokenManager.GenerateToken(loginModel.Username) };
        }

        // PUT api/<LoginController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LoginController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
