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
            return await TryTask<IEnumerable<MapData>>.Run(async () => Ok(await Get.MapData()));
        }

        /// <summary>
        /// gets a single map data of primary key "id"
        /// </summary>
        /// <param name="id">id of item to search</param>
        /// <returns>single map data</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<MapData>> GetAction(int id)
        {
            return await TryTask<MapData>.Run(async () => Ok(await Get.MapData(id)));
        }

        /// <summary>
        /// retrieves a list of map items within a specified radius
        /// </summary>
        /// <param name="North"></param>
        /// <param name="West"></param>
        /// <param name="Radius"></param>
        /// <returns></returns>
        [HttpGet("{North}/{West}/{Radius}")]
        public async Task<ActionResult<IEnumerable<MapData>>> GetAction(decimal North, decimal West, decimal Radius)
        {
            return await TryTask<IEnumerable<MapData>>.Run(async () => Ok(await Get.MapData(North, West, Radius)));
        }

        /// <summary>
        /// retrieves a list of map items within a given city
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        [HttpGet("City/{city}")]
        public async Task<ActionResult<IEnumerable<MapData>>> GetActionCity(string city)
        {
            return await TryTask<IEnumerable<MapData>>.Run(async () => Ok(await Get.MapData(item => item.City == city)));
        }

        /// <summary>
        /// retrieves a list of all map items within the given state
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        [HttpGet("State/{state}")]
        public async Task<ActionResult<MapData>> GetActionState(string state)
        {
            return await TryTask<MapData>.Run(async () => Ok(await Get.MapData(item => item.State == state)));
        }

    }
}
