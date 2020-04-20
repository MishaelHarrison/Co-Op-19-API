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

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(UsersView))]
        [ProducesResponseType(400)]
        public async Task<ActionResult<UsersView>> PostAsync([FromBody] UsersView User)
        {
            await Post.AddUser(User);
            return Ok(User);
        }
    }
}
