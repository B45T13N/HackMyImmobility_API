using HackMyImmobility_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HackMyImmobility_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlatsController : ControllerBase
    {
        
        // GET: api/<LogementsController>
        [HttpGet]
        [Route("liste")]
        public string Get()
        {
            var contextOptions = new DbContextOptionsBuilder<Context>()
            .UseSqlServer(@"Server=DESKTOP-9DMVVHN;user id=utilisateurBDD;pwd=Pa$$w0rd;Database=HackMyImmobility_DB")
            .Options;
            var context = new Context(contextOptions);

            List<Flat> flatsList = context.Flats.ToList();
            if (flatsList.Any())
            {
                var result = "";
                foreach (Flat item in flatsList)
                {
                    result += JObject.FromObject(item);
                }
                return result.ToString() ;
            }
            else
            {
                return "Null";
            }
        }

        // GET api/<LogementsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            var contextOptions = new DbContextOptionsBuilder<Context>()
               .UseSqlServer(@"Server=DESKTOP-9DMVVHN;user id=utilisateurBDD;pwd=Pa$$w0rd;Database=HackMyImmobility_DB")
               .Options;
            var context = new Context(contextOptions);
            var flat = context.Flats.Find(id);

            if (flat == null)
            {
                return "Null";
            }

            return JObject.FromObject(flat).ToString();
        }

        // POST api/<LogementsController>
        [HttpPost]
        public void Post([FromBody] Object content)
        {
            var requestFlat = JObject.Parse(content.ToString());

            var contextOptions = new DbContextOptionsBuilder<Context>()
               .UseSqlServer(@"Server=DESKTOP-9DMVVHN;user id=utilisateurBDD;pwd=Pa$$w0rd;Database=HackMyImmobility_DB")
               .Options;
            var context = new Context(contextOptions);

            Flat newFlat = new Flat
            {
                Address = requestFlat["address"].ToString(),
                EaseWheelchair = bool.Parse(requestFlat["easeWheelChair"].ToString()),
                EaseBlind = bool.Parse(requestFlat["easeBlind"].ToString()),
                EasePartiallyBlind = bool.Parse(requestFlat["easePartiallyBlind"].ToString()),
                EaseDeaf = bool.Parse(requestFlat["easeDeaf"].ToString()),
                EaseMental = bool.Parse(requestFlat["easeMental"].ToString()),
                EaseElderlyPeople = bool.Parse(requestFlat["easeElderlyPeople"].ToString()),
                EaseAmputee = bool.Parse(requestFlat["easeAmputee"].ToString()),
                EaseCare = bool.Parse(requestFlat["easeCare"].ToString()),
                EaseDoctor = bool.Parse(requestFlat["easeDoctor"].ToString()),
                EaseMarket = bool.Parse(requestFlat["easeMarket"].ToString()),
                Email = requestFlat["email"].ToString(),
                Description = requestFlat["description"].ToString(),
                Lat = double.Parse(requestFlat["lat"].ToString()),
                Lng = double.Parse(requestFlat["lng"].ToString()),
            };

            if(requestFlat["url"]!= null)
            {
                newFlat.URL = requestFlat["url"].ToString();
            }
            
            context.Add(newFlat);
            context.SaveChanges();
        }
     
    }
}
