using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace powerplant_coding_challenge_api.Controllers
{
    [Route("/productionplan")]
    [ApiController]
    public class ProductionPlanController : ControllerBase
    {
        // GET: api/<ProductionPlanController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ProductionPlanController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProductionPlanController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductionPlanController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductionPlanController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
