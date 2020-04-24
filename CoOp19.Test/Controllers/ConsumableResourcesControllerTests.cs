using Xunit;
using CoOp19.App.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using Moq;
using CoOp19.Lib;

namespace CoOp19.App.Controllers.Tests
{
    public class ConsumableResourcesControllerTests
    {
        public ConsumableResourcesControllerTests()
        {
            Mock<ILogger<ConsumableResourcesController>> log = new Mock<ILogger<ConsumableResourcesController>>();
            subject = new ConsumableResourcesController(log.Object);
        }

        public Mock<IGet> NewGet => new Mock<IGet>();

        public ConsumableResourcesController subject;

        [Fact()]
        public async void GetListTest()
        {
            var get = NewGet;
            get.Setup(x => x.Consumables());

            await subject.GetAction(get.Object);

            get.Verify(x => x.Consumables(), Times.Exactly(1));
        }

        [Fact()]
        public void GetSingleTest()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void GetGPSTest()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void GetCityTest()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void GetStateTest()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void PostTest()
        {
            Assert.True(false, "This test needs an implementation");
        }
    }
}