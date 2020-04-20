using CoOp19.Dtb;
using CoOp19.Dtb.Entities;
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
        public async Task<ActionResult<IEnumerable<MapData>>> Get()
        {
            return Ok(await Lib.Get.MapData());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<MapData>>> Get(int id)
        {
            return Ok(await Lib.Get.MapData(id));
        }

    }
}
