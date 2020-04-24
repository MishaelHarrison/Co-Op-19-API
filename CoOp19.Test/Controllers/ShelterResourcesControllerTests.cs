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
    public class ShelterResourcesControllerTests
    {
        public ShelterResourcesControllerTests()
        {
            Mock<ILogger<ShelterResourcesController>> log = new Mock<ILogger<ShelterResourcesController>>();
            subject = new ShelterResourcesController(log.Object);
        }

        public Mock<IPost> NewPost => new Mock<IPost>();
        public Mock<IGet> NewGet => new Mock<IGet>();

        public ShelterResourcesController subject;

        [Fact()]
        public async void GetListTest()
        {
            var get = NewGet;
            get.Setup(x => x.Shelters());

            await subject.GetActionAsync(get.Object);

            get.Verify(x => x.Shelters(), Times.Exactly(1));
        }

        [Fact()]
        public async void GetSingleTest()
        {
            var get = NewGet;
            int testInt = 3;
            get.Setup(x => x.Shelter(testInt));

            await subject.GetOneActionAsync(get.Object, testInt);

            get.Verify(x => x.Shelter(testInt), Times.Exactly(1));
        }

        [Fact()]
        public async void GetGPSTest()
        {
            var get = NewGet;

            decimal gpsn = 1;
            decimal gpsw = 2;
            decimal radius = 3;

            get.Setup(x => x.Shelters(gpsn, gpsw, radius));

            await subject.GetAction(get.Object, gpsn, gpsw, radius);

            get.Verify(x => x.Shelters(gpsn, gpsw, radius), Times.Exactly(1));
        }

        [Fact()]
        public async void PostTest()
        {
            var post = NewPost;

            var shelter = new ShelterViewResource();

            post.Setup(x => x.AddShelterResource(shelter)).Returns(Task.Delay(10));

            var ret = await subject.PostAsync(post.Object, shelter);

            Assert.Equal(ret.Value, shelter);

            post.Verify(x => x.AddShelterResource(shelter), Times.Exactly(1));
        }
    }
}
