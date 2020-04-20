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

        [HttpGet("{North}/{West}/{Radius}")]
        public async Task<ActionResult<ShelterViewResource>> GetAction(decimal North, decimal West, decimal Radius)
        {
            return Ok(await Get.Shelters(North, West, Radius));
        }

        [HttpGet("City/{city}")]
        public async Task<ActionResult<ShelterViewResource>> GetActionCity(string city)
        {
            return Ok(await Get.Shelters(item => item.City == city));
        }

        [HttpGet("State/{state}")]
        public async Task<ActionResult<ShelterViewResource>> GetActionState(string state)
        {
            return Ok(await Get.Shelters(item => item.State == state));
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
