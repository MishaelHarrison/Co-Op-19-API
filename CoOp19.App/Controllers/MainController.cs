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

        [HttpGet("{North}/{West}/{Radius}")]
        public async Task<ActionResult<MapData>> GetAction(decimal North, decimal West, decimal Radius)
        {
            return Ok(await Get.HealthResources(North, West, Radius));
        }

        [HttpGet("City/{city}")]
        public async Task<ActionResult<MapData>> GetActionCity(string city)
        {
            return Ok(await Get.HealthResources(item => item.City == city));
        }

        [HttpGet("State/{state}")]
        public async Task<ActionResult<MapData>> GetActionState(string state)
        {
            return Ok(await Get.HealthResources(item => item.State == state));
        }

    }
}
