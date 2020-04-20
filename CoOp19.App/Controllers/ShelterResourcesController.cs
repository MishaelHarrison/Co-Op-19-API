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
    public class ShelterResourcesController : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<ShelterViewResource>> GetActionAsync()
        {
            return await Get.Shelters();
        }

        [HttpGet("{ID}")]
        public async Task<ShelterViewResource> GetOneActionAsync(int id)
        {
            return await Get.Shelter(id);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(ShelterViewResource))]
        [ProducesResponseType(400)]
        public async Task<ActionResult<ShelterViewResource>> PostAsync([FromBody] ShelterViewResource shelt)
        {
            await Post.AddShelterResource(shelt);
            return Ok(shelt);
        }
    }
}
