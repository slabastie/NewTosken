using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using NewTosken.Models;

namespace NewTosken.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CombatController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public CombatController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]

        public JsonResult Get()
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("ToskeAppCon"));

            var dblist = dbClient.GetDatabase("tosken").GetCollection<combat>("combat").AsQueryable();

            return new JsonResult(dblist);
        }
    }
}
