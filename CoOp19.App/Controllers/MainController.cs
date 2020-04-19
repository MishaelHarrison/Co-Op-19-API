using CoOp19.Dtb;
using CoOp19.Dtb.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;


namespace CoOp19.App.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<MapData>> Get()
        {
            return Ok(Lib.Get.MapData());
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<MapData>> Get(int id)
        {
            var output = new List<MapData>();
            using (var context = new DB19Context())
            {
                return Ok(context.MapData.Find(id));
            }
        }

    }
}
