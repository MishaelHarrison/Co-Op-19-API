using CoOp19.Lib;
using CoOp19.Lib.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoOp19.App.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ConsumableResourcesController : ControllerBase
    {
        private readonly ILogger log;

        public ConsumableResourcesController(ILogger<ConsumableResourcesController> logger)
        {
            log = logger;
        }
        
        /// <summary>
        /// retrieves a list of all consumables
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConsumableViewResource>>> GetActionCity([FromServices] IGet get)
        {
            log.LogInformation("Querrying all consumable resources");
            return await TryTask<IEnumerable<ConsumableViewResource>>.Run(async () => Ok(await get.Consumables()));
        }
        /// <summary>
        /// gets a single consumable of primary key "id"
        /// </summary>
        /// <param name = "id">id of item to serach</param>
        /// <returns> single consumable</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ConsumableViewResource>> GetAction([FromServices] IGet get, int id)
        {
            log.LogInformation($"Querring the database for a consumable resource with id:{id}");
            return await TryTask<ConsumableViewResource>.Run(async () => Ok(await get.Consumable(id)));
        }
        /// <summary>
        /// retrieves all consumables within a specified radius
        /// </summary>
        /// <param name="North"></param>
        /// <param name="West"></param>
        /// <param name="Radius"></param>
        /// <returns> cordinates of that location</returns>
        [HttpGet("{North}/{West}/{Radius}")]
        public async Task<ActionResult<IEnumerable<ConsumableViewResource>>> GetAction([FromServices] IGet get, decimal North, decimal West, decimal Radius)
        {
            log.LogInformation($"querrys the data base for all items within {Radius} miles of N{North}, W{West}");
            return await TryTask<IEnumerable<ConsumableViewResource>>.Run(async () => Ok(await get.Consumables(North, West, Radius)));
        }
        /// <summary>
        /// retrieves all consumables within a given city
        /// </summary>
        /// <param name="city"></param>
        /// <returns>a single city with its consumables</returns>
        [HttpGet("City/{city}")]
        public async Task<ActionResult<IEnumerable<ConsumableViewResource>>> GetActionCity([FromServices] IGet get, string city)
        {
            log.LogInformation($"querrys the database for all consumable resources in {city}");
            return await TryTask<IEnumerable<ConsumableViewResource>>.Run(async () => Ok(await get.Consumables(item => item.City == city)));
        }
        /// <summary>
        /// retrieves all consumables within a given state
        /// </summary>
        /// <param name="state"></param>
        /// <returns>a single state with its consumables</returns>
        [HttpGet("State/{state}")]
        public async Task<ActionResult<IEnumerable<ConsumableViewResource>>> GetActionState([FromServices] IGet get, string state)
        {
            log.LogInformation($"querrys the database for all consumable resources in {state}");
            return await TryTask<IEnumerable<ConsumableViewResource>>.Run(async () => Ok(await get.Consumables(item => item.State == state)));
        }
        /// <summary>
        /// post a consumable to the database
        /// </summary>
        /// <param name="consume"></param>
        /// <returns>input items with updated ids</returns>
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(ConsumableViewResource))]
        [ProducesResponseType(400)]
        public async Task<ActionResult<ConsumableViewResource>> PostAction([FromServices] IPost post, [FromBody] ConsumableViewResource consume)
        {
            log.LogInformation($"Adding {consume.Name} to consumable resources");
            return await TryTask<ConsumableViewResource>.Run(async () =>
            {
                await post.AddConsumable(consume);
                return consume;
            });
        }
    }
}
