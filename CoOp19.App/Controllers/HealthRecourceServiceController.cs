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
            using (var context = new DB19Context())
            {
                var serv = await context.HealthResourceServices.FindAsync(id);
                var health = await context.HealthResource.FindAsync(serv.RecourceId);
                var gen = await context.GenericResource.FindAsync(health.ResourceId);
                var map = await context.MapData.FindAsync(gen.LocId);
                return new HealthViewResourceService(serv, health, gen, map);
            }
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(HealthViewResourceService))]
        [ProducesResponseType(400)]
        public async Task Post([FromBody] HealthViewResourceService serv)
        {
            await Lib.Post.AddHealthResourceService(serv);
        }
    }
}
