using Xunit;
using CoOp19.App.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using Moq;
using CoOp19.Lib;
using CoOp19.Dtb.Entities;
using CoOp19.Lib.Models;
using System.Threading.Tasks;

namespace CoOp19.App.Controllers.Tests
{
    public class ConsumableResourcesControllerTests
    {
        public ConsumableResourcesControllerTests()
        {
            Mock<ILogger<ConsumableResourcesController>> log = new Mock<ILogger<ConsumableResourcesController>>();
            subject = new ConsumableResourcesController(log.Object);
        }

        public Mock<IPost> NewPost => new Mock<IPost>();
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
        public async void GetSingleTest()
        {
            var get = NewGet;
            int testInt = 3;
            get.Setup(x => x.Consumable(testInt));

            await subject.GetAction(get.Object, testInt);

            get.Verify(x => x.Consumable(testInt), Times.Exactly(1));
        }

        [Fact()]
        public async void GetGPSTest()
        {
            var get = NewGet;

            decimal gpsn = 1;
            decimal gpsw = 2;
            decimal radius = 3;

            get.Setup(x => x.Consumables(gpsn, gpsw, radius));

            await subject.GetAction(get.Object, gpsn, gpsw, radius);

            get.Verify(x => x.Consumables(gpsn, gpsw, radius), Times.Exactly(1));
        }

        [Fact()]
        public async void PostTest()
        {
            var post = NewPost;

            var consume = new ConsumableViewResource();

            post.Setup(x => x.AddConsumable(consume)).Returns(Task.Delay(10));

            var ret = await subject.PostAction(post.Object, consume);

            Assert.Equal(ret.Value, consume);

            post.Verify(x => x.AddConsumable(consume), Times.Exactly(1));
        }
    }
}