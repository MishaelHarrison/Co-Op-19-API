using CoOp19.Lib;
using CoOp19.Lib.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoOp19.App.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ConsumableResourcesController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConsumableViewResource>>> GetAction()
        {
            return Ok(await Get.Consumables());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ConsumableViewResource>> GetAction(int id)
        {
            return Ok(await Get.Consumable(id));
        }
        
        [HttpGet("{North}/{West}/{Radius}")]
        public async Task<ActionResult<ConsumableViewResource>> GetAction(decimal North, decimal West, decimal Radius)
        {
            return Ok(await Get.Consumables(North, West, Radius));
        }

        [HttpGet("City/{city}")]
        public async Task<ActionResult<ConsumableViewResource>> GetActionCity(string city)
        {
            return Ok(await Get.Consumables(item => item.City == city));
        }

        [HttpGet("State/{state}")]
        public async Task<ActionResult<ConsumableViewResource>> GetActionState(string state)
        {
            return Ok(await Get.Consumables(item => item.State == state));
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(ConsumableViewResource))]
        [ProducesResponseType(400)]
        public async Task<ActionResult<ConsumableViewResource>> PostAction([FromBody] ConsumableViewResource consume)
        {
            await Post.AddConsumable(consume);
            return consume;
        }
    }
}
