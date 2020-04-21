using CoOp19.Dtb;
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
        public async Task<ActionResult<IEnumerable<HealthViewResourceService>>> Get()
        {
            return Ok(await Lib.Get.HealthServices());
        }
        /// <summary>
        /// gets a single healthservice resource by "id"
        /// </summary>
        /// <param name="id"></param>
        /// <returns>a single healthservice resource</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<HealthViewResourceService>> Get(int id)
        {
            return await Lib.Get.HealthService(id);
        }
        /// <summary>
        /// adds a single health service to health resource service
        /// </summary>
        /// <param name="serv"></param>
        /// <returns>a single health service resource</returns>
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(HealthViewResourceService))]
        [ProducesResponseType(400)]
        public async Task<HealthViewResourceService> Post([FromBody] HealthViewResourceService serv)
        {
            await Lib.Post.AddHealthResourceService(serv);
            return serv;
        }
    }
}
