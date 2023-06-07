using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using NewTosken.Models;
using System.Linq;

namespace NewTosken.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public PlayersController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]

        public JsonResult Get()
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("ToskeAppCon"));

            var dblist = dbClient.GetDatabase("tosken").GetCollection<players>("players").AsQueryable();

            return new JsonResult(dblist);
        }

        [HttpPost]
        public JsonResult Post(players play)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("ToskeAppCon"));

            dbClient.GetDatabase("tosken").GetCollection<players>("players").InsertOne(play);

            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public JsonResult Put(players play)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("ToskeAppCon"));

            var filter = Builders<players>.Filter.Eq("name", play.name);

            var update = Builders<players>.Update.Set("current_health", play.current_health);

            dbClient.GetDatabase("tosken").GetCollection<players>("players").UpdateOne(filter,update);

            return new JsonResult("Updated Successfully");
        }

    }
}
