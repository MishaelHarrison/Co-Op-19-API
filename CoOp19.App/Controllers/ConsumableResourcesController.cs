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
        /// <summary>
        /// gets a single consumable of primary key "id"
        /// </summary>
        /// <param name = "id">id of item to serach</param>
        /// <returns> single consumable</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ConsumableViewResource>> GetAction(int id)
        {
            return Ok(await Get.Consumable(id));
        }
        /// <summary>
        /// gets the GPS consumables cordinates for primary key "id"
        /// </summary>
        /// <param name="North"></param>
        /// <param name="West"></param>
        /// <param name="Radius"></param>
        /// <returns> cordinates of that location</returns>
        [HttpGet("{North}/{West}/{Radius}")]
        public async Task<ActionResult<ConsumableViewResource>> GetAction(decimal North, decimal West, decimal Radius)
        {
            return Ok(await Get.Consumables(North, West, Radius));
        }
        /// <summary>
        /// gets the city with consumable using primary key "id"
        /// </summary>
        /// <param name="city"></param>
        /// <returns>a single city with its consumables</returns>
        [HttpGet("City/{city}")]
        public async Task<ActionResult<ConsumableViewResource>> GetActionCity(string city)
        {
            return Ok(await Get.Consumables(item => item.City == city));
        }
        /// <summary>
        /// gets the state with consumable with primary key "id"
        /// </summary>
        /// <param name="state"></param>
        /// <returns>a single state with its consumables</returns>
        [HttpGet("State/{state}")]
        public async Task<ActionResult<ConsumableViewResource>> GetActionState(string state)
        {
            return Ok(await Get.Consumables(item => item.State == state));
        }
        /// <summary>
        /// adds a consumable to consumable resources
        /// </summary>
        /// <param name="consume"></param>
        /// <returns>a single consumable</returns>
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
