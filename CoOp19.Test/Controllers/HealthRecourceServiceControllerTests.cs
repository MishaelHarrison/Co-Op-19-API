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
    public class HealthRecourceServiceControllerTests
    {
        public HealthRecourceServiceControllerTests()
        {
            Mock<ILogger<HealthRecourceServiceController>> log = new Mock<ILogger<HealthRecourceServiceController>>();
            subject = new HealthRecourceServiceController(log.Object);
        }

        public Mock<IPost> NewPost => new Mock<IPost>();
        public Mock<IGet> NewGet => new Mock<IGet>();

        public HealthRecourceServiceController subject;

        [Fact()]
        public async void GetListTest()
        {
            var get = NewGet;
            get.Setup(x => x.HealthServices());

            await subject.GetAction(get.Object);

            get.Verify(x => x.HealthServices(), Times.Exactly(1));
        }

        [Fact()]
        public async void GetSingleTest()
        {
            var get = NewGet;
            int testInt = 3;
            get.Setup(x => x.HealthService(testInt));

            await subject.GetAction(get.Object, testInt);

            get.Verify(x => x.HealthService(testInt), Times.Exactly(1));
        }

        [Fact()]
        public async void GetGPSTest()
        {
            var get = NewGet;

            decimal gpsn = 1;
            decimal gpsw = 2;
            decimal radius = 3;

            get.Setup(x => x.HealthServices(gpsn, gpsw, radius));

            await subject.GetAction(get.Object, gpsn, gpsw, radius);

            get.Verify(x => x.HealthServices(gpsn, gpsw, radius), Times.Exactly(1));
        }
    }
}
