using Xunit;
using CoOp19.App.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using System.Threading.Tasks;
using CoOp19.Lib.Models;
using Microsoft.Extensions.Logging;
using CoOp19.Lib;

namespace CoOp19.App.Controllers.Tests
{
    public class UsersControllerTests
    {
        public UsersControllerTests()
        {
            Mock<ILogger<UsersController>> log = new Mock<ILogger<UsersController>>();
            subject = new UsersController(log.Object);
        }

        public Mock<IPost> NewPost => new Mock<IPost>();
        public Mock<IGet> NewGet => new Mock<IGet>();

        public UsersController subject;

        [Fact()]
        public async void GetListTest()
        {
            var get = NewGet;
            get.Setup(x => x.Users());

            await subject.GetUsers(get.Object);

            get.Verify(x => x.Users(), Times.Exactly(1));
        }

        [Fact()]
        public async void GetSingleTest()
        {
            var get = NewGet;
            int testInt = 3;
            get.Setup(x => x.User(testInt));

            await subject.GetUserAsync(get.Object, testInt);

            get.Verify(x => x.User(testInt), Times.Exactly(1));
        }

        [Fact()]
        public async void GetGPSTest()
        {
            var get = NewGet;

            decimal gpsn = 1;
            decimal gpsw = 2;
            decimal radius = 3;

            get.Setup(x => x.Users(gpsn, gpsw, radius));

            await subject.GetAction(get.Object, gpsn, gpsw, radius);

            get.Verify(x => x.Users(gpsn, gpsw, radius), Times.Exactly(1));
        }
    }
}