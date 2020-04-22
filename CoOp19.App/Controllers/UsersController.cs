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
        /// <summary>
        /// retrieves a full list of users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsersView>>> GetUsers()
        {
            return Ok(await Get.Users());
        }

        /// <summary>
        /// retrieves a single user
        /// </summary>
        /// <param name="id">id of user</param>
        /// <returns></returns>
        [HttpGet("{ID}")]
        public async Task<UsersView> GetUserAsync(int id)
        {
            return await Get.User(id);
        }

        /// <summary>
        /// retrieves all users within a radius
        /// </summary>
        /// <param name="North"></param>
        /// <param name="West"></param>
        /// <param name="Radius"></param>
        /// <returns>querried list of users</returns>
        [HttpGet("{North}/{West}/{Radius}")]
        public async Task<ActionResult<UsersView>> GetAction(decimal North, decimal West, decimal Radius)
        {
            return Ok(await Get.Users(North, West, Radius));
        }

        /// <summary>
        /// returns all users within the specified city
        /// </summary>
        /// <param name="city">name of city</param>
        /// <returns>querryed list</returns>
        [HttpGet("City/{city}")]
        public async Task<ActionResult<UsersView>> GetActionCity(string city)
        {
            return Ok(await Get.Users(item => item.City == city));
        }

        /// <summary>
        /// returns all users within a specified state
        /// </summary>
        /// <param name="state">querying state</param>
        /// <returns>list of users</returns>
        [HttpGet("State/{state}")]
        public async Task<ActionResult<UsersView>> GetActionState(string state)
        {
            return Ok(await Get.Users(item => item.State == state));
        }

        /// <summary>
        /// returns the user with a specified username
        /// </summary>
        /// <param name="city">name of city</param>
        /// <returns>querryed list</returns>
        [HttpGet("username/{U}")]
        public async Task<ActionResult<UsersView>> GetActionUserName(string U)
        {
            return Ok(await Get.Users(item => item.UserName.Trim() == U));
        }

        /// <summary>
        /// enters a new user to the database
        /// </summary>
        /// <param name="User">input</param>
        /// <returns>item with updated values</returns>
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
