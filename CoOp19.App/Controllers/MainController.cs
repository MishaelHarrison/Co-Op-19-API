using CoOp19.Dtb;
using CoOp19.Dtb.Entities;
using CoOp19.Lib;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoOp19.App.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainController : ControllerBase
    {
        /// <summary>
        /// retrieves a list of all map items
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MapData>>> GetAction()
        {
            return Ok(await Get.MapData());
        }

        /// <summary>
        /// gets a single map data of primary key "id"
        /// </summary>
        /// <param name="id">id of item to search</param>
        /// <returns>single map data</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<MapData>>> GetAction(int id)
        {
            return Ok(await Get.MapData(id));
        }

        /// <summary>
        /// retrieves a list of map items within a specified radius
        /// </summary>
        /// <param name="North"></param>
        /// <param name="West"></param>
        /// <param name="Radius"></param>
        /// <returns></returns>
        [HttpGet("{North}/{West}/{Radius}")]
        public async Task<ActionResult<MapData>> GetAction(decimal North, decimal West, decimal Radius)
        {
            return Ok(await Get.HealthResources(North, West, Radius));
        }

        /// <summary>
        /// retrieves a list of map items within a given city
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        [HttpGet("City/{city}")]
        public async Task<ActionResult<MapData>> GetActionCity(string city)
        {
            return Ok(await Get.HealthResources(item => item.City == city));
        }

        /// <summary>
        /// retrieves a list of all map items within the given state
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        [HttpGet("State/{state}")]
        public async Task<ActionResult<MapData>> GetActionState(string state)
        {
            return Ok(await Get.HealthResources(item => item.State == state));
        }

    }
}
