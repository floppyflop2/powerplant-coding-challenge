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

        private IPowerplantManager _powerplantManager;
        private IProductionPlanManager _productionPlanManager;

        public ProductionPlanController(IPowerplantManager powerplantManager, IProductionPlanManager productionPlanManager)
        {
            _powerplantManager = powerplantManager;
            _productionPlanManager = productionPlanManager;
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
        public ActionResult<ProductionPlan[]> ProcessPayload([FromBody] object value)
        {
            if (value == null) return BadRequest();
            try
            {
                var payload = JsonConvert.DeserializeObject<Payload>(value.ToString());
                var powerplantProducers = _powerplantManager.InitializePowerplantProcessers(payload);
                //var productionPlans = _productionPlanManager.PerformCalculation(powerplantProducers, payload.Load);
                var productionPlans = _productionPlanManager.PerformCalculationPricing(powerplantProducers, payload.Load);
                if (productionPlans.Count == 0) return NoContent();

                return Ok(productionPlans);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
