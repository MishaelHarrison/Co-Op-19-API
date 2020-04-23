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
    public class HealthRecourceServiceController : ControllerBase
    {
        private ILogger log;

        public HealthRecourceServiceController(ILogger<HealthRecourceServiceController> logger)
        {
            log = logger;
        }

        /// <summary>
        /// retrieves a list of all health resources
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HealthViewResourceService>>> GetAction()
        {
            log.LogInformation($"Querring the database for all Health services");
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
            log.LogInformation($"Querrying the database for a health resource with id:{id}");
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
            log.LogInformation($"Querrying the database for all health services within {Radius} miles of N{North}, W{West}");
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
            log.LogInformation($"Querrys the database for all health resources in {city}");
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
            log.LogInformation($"Querrys the database for all health resources in {state}");
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
            log.LogInformation($"adding {serv.ServiceName} to the database");
            return await TryTask<HealthViewResourceService>.Run(async () =>
            {
                await Post.AddHealthResourceService(serv);
                return Ok(serv);
            });
        }
    }
}
