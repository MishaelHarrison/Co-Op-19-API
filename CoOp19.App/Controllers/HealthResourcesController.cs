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
        
        [HttpGet("{ID}")]
        public async Task<HealthViewResource> GetHealthResource(int id)
        {
            return await Get.HealthResource(id);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(HealthViewResource))]
        [ProducesResponseType(400)]
        public async Task<ActionResult<HealthViewResource>> PostAsync([FromBody] HealthViewResource health)
        {
            await Post.AddHealthResource(health);
            return Ok(health);
        }
    }
}
