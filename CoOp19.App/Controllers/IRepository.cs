using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoOp19.Dtb.Entities;
using CoOp19.App.Controllers;
using CoOp19.Lib.Models;

namespace CoOp19.App.Controllers
{
    public interface IRepository
    {
        List<MapData> GetMapdatas();
    }
}
