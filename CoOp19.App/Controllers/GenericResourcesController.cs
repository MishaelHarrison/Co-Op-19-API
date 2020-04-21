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
        /// <summary>
        /// gets a single generic resource "id"
        /// </summary>
        /// <param name="id"></param>
        /// <returns>a single generic</returns>
        [HttpGet("{ID}")]
        public async Task<ActionResult<GenericViewResource>> GetAction(int id)
        {
            return Ok(await Get.Generic(id));
        }
        /// <summary>
        /// gets GPS cordinates of generic resources 
        /// </summary>
        /// <param name="North"></param>
        /// <param name="West"></param>
        /// <param name="Radius"></param>
        /// <returns> cordinates of that generic location</returns>
        [HttpGet("{North}/{West}/{Radius}")]
        public async Task<ActionResult<GenericViewResource>> GetAction(decimal North, decimal West, decimal Radius)
        {
            return Ok(await Get.Generics(North, West, Radius));
        }
        /// <summary>
        /// gets the city with its generic resource
        /// </summary>
        /// <param name="city"></param>
        /// <returns>a single city with generic resources</returns>
        [HttpGet("City/{city}")]
        public async Task<ActionResult<GenericViewResource>> GetActionCity(string city)
        {
            return Ok(await Get.Generics(item => item.City == city));
        }
        /// <summary>
        /// gets the state with generic resource
        /// </summary>
        /// <param name="state"></param>
        /// <returns>a single state with generic resource</returns>
        [HttpGet("State/{state}")]
        public async Task<ActionResult<GenericViewResource>> GetActionState(string state)
        {
            return Ok(await Get.Generics(item => item.State == state));
        }
        /// <summary>
        /// adds a single generic to generic resource
        /// </summary>
        /// <param name="gen"></param>
        /// <returns>a single generic resource</returns>
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
