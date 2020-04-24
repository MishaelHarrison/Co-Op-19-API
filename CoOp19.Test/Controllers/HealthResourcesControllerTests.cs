using CoOp19.App.Controllers;
using CoOp19.Lib;
using CoOp19.Lib.Models;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CoOp19.Test.Controllers
{
    public class HealthResourcesControllerTests
    {
        public HealthResourcesControllerTests()
        {
            Mock<ILogger<HealthResourcesController>> log = new Mock<ILogger<HealthResourcesController>>();
            subject = new HealthResourcesController(log.Object);
        }

        public Mock<IPost> NewPost => new Mock<IPost>();
        public Mock<IGet> NewGet => new Mock<IGet>();

        public HealthResourcesController subject;

        [Fact()]
        public async void GetListTest()
        {
            var get = NewGet;
            get.Setup(x => x.HealthResources());

            await subject.GetHealthResources(get.Object);

            get.Verify(x => x.HealthResources(), Times.Exactly(1));
        }

        [Fact()]
        public async void GetSingleTest()
        {
            var get = NewGet;
            int testInt = 3;
            get.Setup(x => x.HealthResource(testInt));

            await subject.GetHealthResource(get.Object, testInt);

            get.Verify(x => x.HealthResource(testInt), Times.Exactly(1));
        }

        [Fact()]
        public async void GetGPSTest()
        {
            var get = NewGet;

            decimal gpsn = 1;
            decimal gpsw = 2;
            decimal radius = 3;

            get.Setup(x => x.HealthResources(gpsn, gpsw, radius));

            await subject.GetAction(get.Object, gpsn, gpsw, radius);

            get.Verify(x => x.HealthResources(gpsn, gpsw, radius), Times.Exactly(1));
        }

        [Fact()]
        public async void PostTest()
        {
            var post = NewPost;

            var health = new HealthViewResource();

            post.Setup(x => x.AddHealthResource(health)).Returns(Task.Delay(10));

            var ret = await subject.PostAsync(post.Object, health);

            Assert.Equal(ret.Value, health);

            post.Verify(x => x.AddHealthResource(health), Times.Exactly(1));
        }
    }
}
