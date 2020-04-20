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

        [HttpGet("{ID}")]
        public async Task<GenericViewResource> GetHealthResource(int id)
        {
            return await Get.Generic(id);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(GenericViewResource))]
        [ProducesResponseType(400)]
        public async Task<ActionResult<GenericViewResource>> PostAsync([FromBody] GenericViewResource gen)
        {
            await Post.AddGeneric(gen);
            return Ok(gen);
        }
    }
}
