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
    public class GenericResourcesControllerTests
    {
        public GenericResourcesControllerTests()
        {
            Mock<ILogger<GenericResourcesController>> log = new Mock<ILogger<GenericResourcesController>>();
            subject = new GenericResourcesController(log.Object);
        }

        public Mock<IPost> NewPost => new Mock<IPost>();
        public Mock<IGet> NewGet => new Mock<IGet>();

        public GenericResourcesController subject;

        [Fact()]
        public async void GetListTest()
        {
            var get = NewGet;
            get.Setup(x => x.Generics());

            await subject.GetAction(get.Object);

            get.Verify(x => x.Generics(), Times.Exactly(1));
        }

        [Fact()]
        public async void GetSingleTest()
        {
            var get = NewGet;
            int testInt = 3;
            get.Setup(x => x.Generic(testInt));

            await subject.GetAction(get.Object, testInt);

            get.Verify(x => x.Generic(testInt), Times.Exactly(1));
        }

        [Fact()]
        public async void GetGPSTest()
        {
            var get = NewGet;

            decimal gpsn = 1;
            decimal gpsw = 2;
            decimal radius = 3;

            get.Setup(x => x.Generics(gpsn, gpsw, radius));

            await subject.GetAction(get.Object, gpsn, gpsw, radius);

            get.Verify(x => x.Generics(gpsn, gpsw, radius), Times.Exactly(1));
        }
    }
}
