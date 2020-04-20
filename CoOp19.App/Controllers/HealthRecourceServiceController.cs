using CoOp19.Dtb;
using CoOp19.Lib;
using CoOp19.Lib.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoOp19.App.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HealthRecourceServiceController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HealthViewResourceService>>> GetAction()
        {
            return Ok(await Get.HealthServices());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HealthViewResourceService>> GetAction(int id)
        {
            return await Get.HealthService(id);
        }

        [HttpGet("{North}/{West}/{Radius}")]
        public async Task<ActionResult<HealthViewResourceService>> GetAction(decimal North, decimal West, decimal Radius)
        {
            return Ok(await Get.HealthServices(North, West, Radius));
        }

        [HttpGet("City/{city}")]
        public async Task<ActionResult<HealthViewResourceService>> GetActionCity(string city)
        {
            return Ok(await Get.HealthServices(item => item.City == city));
        }

        [HttpGet("State/{state}")]
        public async Task<ActionResult<HealthViewResourceService>> GetActionState(string state)
        {
            return Ok(await Get.HealthServices(item => item.State == state));
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(HealthViewResourceService))]
        [ProducesResponseType(400)]
        public async Task<ActionResult<HealthViewResourceService>> PostAction([FromBody] HealthViewResourceService serv)
        {
            await Post.AddHealthResourceService(serv);
            return Ok(serv);
        }
    }
}
