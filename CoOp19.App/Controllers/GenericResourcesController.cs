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
    public class GenericResourcesController : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<GenericViewResource>> GetHealthResources()
        {
            return await Get.Generics();
        }

        public List<ConsumableResource> GetProducts(int id)
        {
            using (var context = new DB19Context())
            {
                var output = new List<ConsumableResource>();
                foreach (var item in context.ConsumableResource)
                {
                    if (item.ResourceId == id)
                    {
                        output.Add(item);
                    }
                }
                return output;
            }
        }

        [HttpGet("{ID}")]
        public async Task<GenericViewResource> GetHealthResource(int id)
        {
            using (var context = new DB19Context())
            {
                var gen = await context.GenericResource.FindAsync(id);
                var map = await context.MapData.FindAsync(gen.LocId);
                var output = new GenericViewResource(map, gen);
                output.ConsumableResources = GetProducts(id);
                return output;
            }
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(GenericViewResource))]
        [ProducesResponseType(400)]
        public async Task<ActionResult> PostAsync([FromBody] GenericViewResource gen)
        {
            await Post.AddGeneric(gen);
            return Ok();
        }
    }
}
