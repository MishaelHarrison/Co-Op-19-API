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

        [HttpGet("{id}")]
        public async Task<ActionResult<HealthViewResourceService>> Get(int id)
        {
            return await Lib.Get.HealthService(id);
        }

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
