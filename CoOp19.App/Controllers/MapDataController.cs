using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoOp19.App.Controllers;
using NuGet.Protocol.Core.Types;

namespace CoOp19.App.Controllers
{
    public class MapDataController
    {
        IRepository repository;
        public class MapDataController(IRepository repository)
        {
            this.repository = repository;
        }
        public void MethodToTest()
        {
            var MapData = this.repository.GetMapData();
            foreach (var map in MapData)
            {
                if (map.City == "Arlington")
                {
                Console.WriteLine("The most resource location");
                }
            }
        }    
    }
 }


