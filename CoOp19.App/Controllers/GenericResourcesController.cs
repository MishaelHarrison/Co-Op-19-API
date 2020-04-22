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
        /// <summary>
        /// retrieves a list of all generic resources
        /// </summary>
        /// <returns></returns>
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
        /// retrieves all generic resources within a specified radius
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
        /// retrieves a list of generic resource within a given city
        /// </summary>
        /// <param name="city"></param>
        /// <returns>a single city with generic resources</returns>
        [HttpGet("City/{city}")]
        public async Task<ActionResult<GenericViewResource>> GetActionCity(string city)
        {
            return Ok(await Get.Generics(item => item.City == city));
        }
        /// <summary>
        /// retrieves a list of generic resources within a given state
        /// </summary>
        /// <param name="state"></param>
        /// <returns>a single state with generic resource</returns>
        [HttpGet("State/{state}")]
        public async Task<ActionResult<GenericViewResource>> GetActionState(string state)
        {
            return Ok(await Get.Generics(item => item.State == state));
        }
        /// <summary>
        /// post a generic resource to the database
        /// </summary>
        /// <param name="gen"></param>
        /// <returns>input items with updated ids</returns>
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
