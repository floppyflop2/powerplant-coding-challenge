using BusinessLayer.interfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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

        private IPowerplantManager _powerCalculator;

        public ProductionPlanController(IPowerplantManager powerCalculator)
        {
            _powerCalculator = powerCalculator;
        }

        // GET: api/<ProductionPlanController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("ok");
        }

        // GET api/<ProductionPlanController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProductionPlanController>
        [HttpPost]
        public IActionResult Post([FromBody] object value)
        {
            if (value == null) return BadRequest();
            var powerPlant = JsonConvert.DeserializeObject<Payload>(value.ToString());

            return Ok();
        }

    }
}
