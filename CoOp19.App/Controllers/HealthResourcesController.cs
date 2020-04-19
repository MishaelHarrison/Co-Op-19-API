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
        [HttpGet]
        public async Task<IEnumerable<HealthViewResource>> GetHealthResources()
        {
            return await Get.HealthResources();
        }

        public List<HealthResourceServices> GetServices(int id)
        {
            using (var context = new DB19Context())
            {
                var output = new List<HealthResourceServices>();
                foreach (var item in context.HealthResourceServices)
                {
                    if (item.RecourceId == id)
                    {
                        output.Add(item);
                    }
                }
                return output;
            }
        }

        [HttpGet("{ID}")]
        public async Task<HealthViewResource> GetHealthResource(int id)
        {
            using (var context = new DB19Context())
            {
                var health = await context.HealthResource.FindAsync(id);
                var gen = await context.GenericResource.FindAsync(health.ResourceId);
                var map = await context.MapData.FindAsync(gen.LocId);
                var output = new HealthViewResource(health, gen, map);
                output.Services = GetServices(id);
                return output;
            }
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(HealthViewResource))]
        [ProducesResponseType(400)]
        public async Task<ActionResult> PostAsync([FromBody] HealthViewResource health)
        {
            await Post.AddHealthResource(health);
            return Ok();
        }
    }
}
