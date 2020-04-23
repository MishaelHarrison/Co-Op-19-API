using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoOp19.App.Controllers;
using CoOp19.Dtb.Entities;

namespace CoOp19.App.Controllers
{
    public class Repository : IRepository
    {
        public List<MapData> GetMapdatas() 
        {
            var listOfMapdatas = new List<MapData>();
            listOfMapdatas.Add(
             new MapData
             {
                 Address = "2344 34th St SW",
                 City = "Arlington",
                 State = "Texas",

             });
            listOfMapdatas.Add(
             new MapData
             {
                 Address = "2891 33th St SW",
                 City = "Los Angeles",
                 State = "California",

             });
            return listOfMapdatas;

        }
         

    }
}
