using CoOp19.Dtb;
using CoOp19.Dtb.Entities;
using CoOp19.Lib;
using CoOp19.Lib.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoOp19.App.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HealthResourcesController : ControllerBase
    {
        /// <summary>
        /// retrieves all health resources
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HealthViewResource>>> GetHealthResources()
        {
            return await TryTask<IEnumerable<HealthViewResource>>.Run(async () => Ok(await Get.HealthResources()));
        }
        /// <summary>
        /// retrieves the healthcontrol resource by "id"
        /// </summary>
        /// <param name="id"></param>
        /// <returns>a sinlge health resource</returns>
        [HttpGet("{ID}")]
        public async Task<ActionResult<HealthViewResource>> GetHealthResource(int id)
        {
            return await TryTask<HealthViewResource>.Run(async () => Ok(await Get.HealthResource(id)));
        }
        /// <summary>
        /// retrieves all health resources within a specified radius
        /// </summary>
        /// <param name="North"></param>
        /// <param name="West"></param>
        /// <param name="Radius"></param>
        /// <returns></returns>
        [HttpGet("{North}/{West}/{Radius}")]
        public async Task<ActionResult<IEnumerable<HealthViewResource>>> GetAction(decimal North, decimal West, decimal Radius)
        {
            return await TryTask<IEnumerable<HealthViewResource>>.Run(async () => Ok(await Get.HealthResources(North, West, Radius)));
        }
        /// <summary>
        /// retrieves all health resources within a given city
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        [HttpGet("City/{city}")]
        public async Task<ActionResult<IEnumerable<HealthViewResource>>> GetActionCity(string city)
        {
            return await TryTask<IEnumerable<HealthViewResource>>.Run(async () => Ok(await Get.HealthResources(item => item.City == city)));
        }
        /// <summary>
        /// retrieves all health resources within a given state
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        [HttpGet("State/{state}")]
        public async Task<ActionResult<IEnumerable<HealthViewResource>>> GetActionState(string state)
        {
            return await TryTask<IEnumerable<HealthViewResource>>.Run(async () => Ok(await Get.HealthResources(item => item.State == state)));
        }
        /// <summary>
        /// Post a health resource to the database
        /// </summary>
        /// <param name="health"></param>
        /// <returns>input items with updated ids</returns>
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(HealthViewResource))]
        [ProducesResponseType(400)]
        public async Task<ActionResult<HealthViewResource>> PostAsync([FromBody] HealthViewResource health)
        {
            return await TryTask<HealthViewResource>.Run(async () =>
            {
                await Post.AddHealthResource(health);
                return Ok(health);
            });
        }
    }
}
