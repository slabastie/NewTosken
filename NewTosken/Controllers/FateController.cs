using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using NewTosken.Models;

namespace NewTosken.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FateController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public FateController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]

        public JsonResult Get()
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("ToskeAppCon"));

            var dblist = dbClient.GetDatabase("tosken").GetCollection<fate>("fate").AsQueryable();

            return new JsonResult(dblist);
        }

        [HttpPost]
        public JsonResult Post(fate fp)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("ToskeAppCon"));

            dbClient.GetDatabase("tosken").GetCollection<fate>("fate").InsertOne(fp);

            return new JsonResult("Added Successfully");
        }

        [HttpPut]
        public JsonResult Put(fate fp)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("ToskeAppCon"));

            var filter = Builders<fate>.Filter.Eq("name", fp.name);

            var update_fate = Builders<fate>.Update.Set("fate",fp.current_fate);
            var update_fate_change = Builders<fate>.Update.Set("fate_change", fp.fate_change);
            var update_fate_reason = Builders<fate>.Update.Set("reason", fp.change_reason);
            var update_fate_date = Builders<fate>.Update.Set("date_time", fp.date_time);

            dbClient.GetDatabase("tosken").GetCollection<fate>("fate").UpdateOne(filter, update_fate);

            return new JsonResult("Updated Successfully");
        }

        [HttpPatch]
        public JsonResult Patch(fate fp)
        {
            MongoClient dbClient = new MongoClient(_configuration.GetConnectionString("ToskeAppCon"));

            var filter = Builders<fate>.Filter.Eq("name", fp.name);

            var update_fate = Builders<fate>.Update.Set("current_health", fp.current_fate);

            dbClient.GetDatabase("tosken").GetCollection<fate>("fate").UpdateOne(filter, update_fate);

            return new JsonResult("Updated Successfully");
        }

    }
}
