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
        public async Task<ActionResult<IEnumerable<GenericViewResource>>> GetAction()
        {
            return Ok(await Get.Generics());
        }

        [HttpGet("{ID}")]
        public async Task<ActionResult<GenericViewResource>> GetAction(int id)
        {
            return Ok(await Get.Generic(id));
        }

        [HttpGet("{North}/{West}/{Radius}")]
        public async Task<ActionResult<GenericViewResource>> GetAction(decimal North, decimal West, decimal Radius)
        {
            return Ok(await Get.Generics(North, West, Radius));
        }

        [HttpGet("City/{city}")]
        public async Task<ActionResult<GenericViewResource>> GetActionCity(string city)
        {
            return Ok(await Get.Generics(item => item.City == city));
        }

        [HttpGet("State/{state}")]
        public async Task<ActionResult<GenericViewResource>> GetActionState(string state)
        {
            return Ok(await Get.Generics(item => item.State == state));
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(GenericViewResource))]
        [ProducesResponseType(400)]
        public async Task<ActionResult<GenericViewResource>> PostAction([FromBody] GenericViewResource gen)
        {
            await Post.AddGeneric(gen);
            return Ok(gen);
        }
    }
}
