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
        /// <summary>
        /// retrieves a list of all shelters
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<ShelterViewResource>> GetActionAsync()
        {
            return await Get.Shelters();
        }

        /// <summary>
        /// retrieves the shelter with id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{ID}")]
        public async Task<ShelterViewResource> GetOneActionAsync(int id)
        {
            return await Get.Shelter(id);
        }

        /// <summary>
        /// retrieves all shelters within a specified radius
        /// </summary>
        /// <param name="North">GPS North</param>
        /// <param name="West">GPS West</param>
        /// <param name="Radius">Radius</param>
        /// <returns></returns>
        [HttpGet("{North}/{West}/{Radius}")]
        public async Task<ActionResult<ShelterViewResource>> GetAction(decimal North, decimal West, decimal Radius)
        {
            return Ok(await Get.Shelters(North, West, Radius));
        }

        /// <summary>
        /// retrieves a list of all shelters within a specified state
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        [HttpGet("City/{city}")]
        public async Task<ActionResult<ShelterViewResource>> GetActionCity(string city)
        {
            return Ok(await Get.Shelters(item => item.City == city));
        }

        /// <summary>
        /// retrieves a list of all shelters within a given state
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        [HttpGet("State/{state}")]
        public async Task<ActionResult<ShelterViewResource>> GetActionState(string state)
        {
            return Ok(await Get.Shelters(item => item.State == state));
        }

        /// <summary>
        /// posts a shelter to the database
        /// </summary>
        /// <param name="shelt">input</param>
        /// <returns>inputed item with updated ids</returns>
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
