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
       
        /// <summary>
        /// retrieves a list of all health resources
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HealthViewResourceService>>> GetAction()
        {
            return await TryTask<IEnumerable<HealthViewResourceService>>.Run(async () => Ok(await Get.HealthServices()));
        }
        /// <summary>
        /// gets a single healthservice resource by "id"
        /// </summary>
        /// <param name="id"></param>
        /// <returns>a single healthservice resource</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<HealthViewResourceService>> GetAction(int id)
        {
            return await TryTask<HealthViewResourceService>.Run(async () => await Get.HealthService(id));
        }
        /// <summary>
        /// retrives all health resources within a specified radius
        /// </summary>
        /// <param name="North"></param>
        /// <param name="West"></param>
        /// <param name="Radius"></param>
        /// <returns></returns>
        [HttpGet("{North}/{West}/{Radius}")]
        public async Task<ActionResult<IEnumerable<HealthViewResourceService>>> GetAction(decimal North, decimal West, decimal Radius)
        {
            return await TryTask<IEnumerable<HealthViewResourceService>>.Run(async () => Ok(await Get.HealthServices(North, West, Radius)));
        }
        /// <summary>
        /// retrieves all health resources within a given city
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        [HttpGet("City/{city}")]
        public async Task<ActionResult<IEnumerable<HealthViewResourceService>>> GetActionCity(string city)
        {
            return await TryTask<IEnumerable<HealthViewResourceService>>.Run(async () => Ok(await Get.HealthServices(item => item.City == city)));
        }
        /// <summary>
        /// retrieves all health resources within a given state
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        [HttpGet("State/{state}")]
        public async Task<ActionResult<IEnumerable<HealthViewResourceService>>> GetActionState(string state)
        {
            return await TryTask<IEnumerable<HealthViewResourceService>>.Run(async () => Ok(await Get.HealthServices(item => item.State == state)));
        }
        /// <summary>
        /// post a health service to the database
        /// </summary>
        /// <param name="serv"></param>
        /// <returns>input items with updated ids</returns>
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(HealthViewResourceService))]
        [ProducesResponseType(400)]
        public async Task<ActionResult<HealthViewResourceService>> PostAction([FromBody] HealthViewResourceService serv)
        {
            return await TryTask<HealthViewResourceService>.Run(async () =>
            {
                await Post.AddHealthResourceService(serv);
                return Ok(serv);
            });
        }
    }
}
