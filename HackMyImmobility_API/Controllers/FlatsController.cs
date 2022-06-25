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
                return result.ToString();
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
            System.Diagnostics.Debug.WriteLine(content);

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

            if (requestFlat["url"] != null)
            {
                newFlat.URL = requestFlat["url"].ToString();
            }
            else
            {
                newFlat.URL = "";
            }

            context.Add(newFlat);
            context.SaveChanges();
        }

        // POST api/<LogementsController>
        [HttpPost]
        [Route("filtre")]
        public string Filter([FromBody] Object content)
        {
            var requestFilter = JObject.Parse(content.ToString());

            var contextOptions = new DbContextOptionsBuilder<Context>()
               .UseSqlServer(@"Server=DESKTOP-9DMVVHN;user id=utilisateurBDD;pwd=Pa$$w0rd;Database=HackMyImmobility_DB")
               .Options;
            var context = new Context(contextOptions);

            var listFilteredFlats = new List<Flat>();

            if (requestFilter["easeWheelChair"] != null && bool.Parse(requestFilter["easeWheelChair"].ToString())== true)
            {
                listFilteredFlats = context.Flats.Where(f => f.EaseWheelchair == true).ToList();
            } 
            else if (requestFilter["easeBlind"] != null && bool.Parse(requestFilter["easeBlind"].ToString()) == true)
            {
                listFilteredFlats = context.Flats.Where(f => f.EaseBlind == true).ToList();
            }
            else if (requestFilter["easePartiallyBlind"] != null && bool.Parse(requestFilter["easePartiallyBlind"].ToString()) == true)
            {
                listFilteredFlats = context.Flats.Where(f => f.EasePartiallyBlind == true).ToList();
            }
            else if (requestFilter["easeDeaf"] != null &&  bool.Parse(requestFilter["easeDeaf"].ToString()) == true)
            {
                listFilteredFlats = context.Flats.Where(f => f.EaseDeaf == true).ToList();
            }
            else if (requestFilter["easeMental"] != null && bool.Parse(requestFilter["easeMental"].ToString()) == true)
            {
                listFilteredFlats = context.Flats.Where(f => f.EaseMental == true).ToList();
            }
            else if (requestFilter["easeElderlyPeople"] != null && bool.Parse(requestFilter["easeElderlyPeople"].ToString()) == true)
            {
                listFilteredFlats = context.Flats.Where(f => f.EaseElderlyPeople == true).ToList();
            }
            else if (requestFilter["easeAmputee"] != null && bool.Parse(requestFilter["easeAmputee"].ToString()) == true)
            {
                listFilteredFlats = context.Flats.Where(f => f.EaseAmputee == true).ToList();
            }
            else if (requestFilter["easeCare"] != null && bool.Parse(requestFilter["easeCare"].ToString()) == true)
            {
                listFilteredFlats = context.Flats.Where(f => f.EaseCare == true).ToList();
            }
            else if (requestFilter["easeMarket"] != null && bool.Parse(requestFilter["easeMarket"].ToString()) == true)
            {
                listFilteredFlats = context.Flats.Where(f => f.EaseMarket == true).ToList();
            }
            else if (requestFilter["easeDoctor"] != null && bool.Parse(requestFilter["easeDoctor"].ToString()) == true)
            {
                listFilteredFlats = context.Flats.Where(f => f.EaseDoctor == true).ToList();
            }

            if (requestFilter.ContainsKey("distance") || Int32.Parse(requestFilter["distance"].ToString()) >= 0)
            {
                var dist = double.Parse(requestFilter["distance"].ToString()) * 1000;
                var lat0 = double.Parse(requestFilter["lat"].ToString());
                var lng0 = double.Parse(requestFilter["lng"].ToString());

                var latMin = lat0 - (180 / Math.PI) * (dist / 6378137);
                var latMax = lat0 + (180 / Math.PI) * (dist / 6378137);
                var lngMin = lng0 - (180 / Math.PI) * (dist / 6378137)/Math.Cos(Math.PI / 180.0 * lat0);
                var lngMax = lng0 + (180 / Math.PI) * (dist / 6378137)/Math.Cos(Math.PI / 180.0 * lat0);

                listFilteredFlats = context.Flats.Where(f => latMin < f.Lat).Where(f => f.Lat < latMax).Where(f => lngMin < f.Lng).Where(f => f.Lng < lngMax).ToList();
            }

            listFilteredFlats = listFilteredFlats.Distinct().ToList();

            if (listFilteredFlats.Any())
            {
                var result = "";
                foreach (Flat item in listFilteredFlats)
                {
                    result += JObject.FromObject(item);
                }
                return result.ToString();
            }
            else
            {
                return "Null";
            }
        }


    }
}
