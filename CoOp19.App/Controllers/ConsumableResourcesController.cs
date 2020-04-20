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
        public async Task<ActionResult<IEnumerable<ConsumableViewResource>>> GetActionAsync()
        {
            return Ok(await Get.Consumables());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ConsumableViewResource>> GetActionAsync(int id)
        {
            return Ok(await Get.Consumable(id));
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(ConsumableViewResource))]
        [ProducesResponseType(400)]
        public async Task<ActionResult<ConsumableViewResource>> Post([FromBody] ConsumableViewResource consume)
        {
            await Lib.Post.AddConsumable(consume);
            return consume;
        }
    }
}
