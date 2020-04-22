using CoOp19.App.Controllers;
using System;
using Xunit;
using CoOp19.App.Controllers;
using CoOp19.Lib.Models;
using System.Collections.Generic;
using CoOp19.Dtb;
using CoOp19.Dtb.Entities;
using System.Threading.Tasks;

namespace CoOp19.Test
{
    public class TestControllers
    {
        //private UsersController user = new UsersController(new DB19Context());
        [Fact]
        public void Test_Users()
        {
            var actual = users.GetUsers();
            Assert.True(actual != null);
            Assert.True(actual.Count >= 0);
        }
        //private ConsumableResourcesController consumable = new ConsumableResourceController(new DB19Context());
        [Fact]
        public void Test_ConsumableResource()
        {
            var actual = consumable.GetConsumableResource();
            Assert.True(actual != null);
            Assert.True(actual.Count >= 0);
        }
       
    }
    
}
