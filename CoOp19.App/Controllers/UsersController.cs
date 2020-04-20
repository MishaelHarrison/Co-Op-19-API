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
    public class UsersController : ControllerBase
    {
        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsersView>>> GetUsers()
        {
            return Ok(await Get.Users());
        }

        [HttpGet("{ID}")]
        public async Task<UsersView> GetUserAsync(int id)
        {
            return await Get.User(id);
        }

        [HttpGet("{North}/{West}/{Radius}")]
        public async Task<ActionResult<UsersView>> GetAction(decimal North, decimal West, decimal Radius)
        {
            return Ok(await Get.Users(North, West, Radius));
        }

        [HttpGet("City/{city}")]
        public async Task<ActionResult<UsersView>> GetActionCity(string city)
        {
            return Ok(await Get.Users(item => item.City == city));
        }

        [HttpGet("State/{state}")]
        public async Task<ActionResult<UsersView>> GetActionState(string state)
        {
            return Ok(await Get.Users(item => item.State == state));
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(UsersView))]
        [ProducesResponseType(400)]
        public async Task<ActionResult<UsersView>> PostAsync([FromBody] UsersView User)
        {
            await Post.AddUser(User);
            return User;
        }
    }
}
