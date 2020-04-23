using CoOp19.App.Controllers;
using System;
using Xunit;
using FluentAssertions;
using CoOp19.App.Controllers;
using CoOp19.Lib.Models;
using System.Collections.Generic;
using CoOp19.Dtb;
using CoOp19.Dtb.Entities;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CoOp19.Test
{
    
    public class MapdataControllersTest
    {

        [Fact]
        public void MapDataToTest()
        {
            // create list of Mapdata to return.
            var listOfMapData = new List<MapData>();
            listOfMapData.Add(new MapData
            {
               Address = "2344 34th St SW",
               City = "Arlington",
               State = "Texas",
            });

            Mock < IRepository > = mockRepository = new Mock<IRepository>();
            MockRepository.Setup(x => x.GetMapdatas()).Returns(listOfMapData);
            var mapdataController = new MapdataController(mockRepository.Object);
            MapDataController.MethodToTest();
            mapdataController.Should().NotBeNull();
        }

        private class MapdataController
        {
            private object @object;

            public MapdataController(object @object)
            {
                this.@object = @object;
            }
        }
    }
    
}
