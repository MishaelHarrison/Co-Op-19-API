using Xunit;
using CoOp19.Lib;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using Moq;
using CoOp19.App.Controllers;
using CoOp19.Dtb;
using Autofac.Extras.Moq;
using CoOp19.Test;
using CoOp19.Dtb.Entities;
using System.Threading.Tasks;

namespace CoOp19.Lib.Tests
{
    public class GetTests
    {
        [Fact()]
        public void ConsumablesTest()
        {
            Mock<IOutput> output = new Mock<IOutput>();
            var subject = new Get(output.Object);

            //output.Setup(x => Get<ConsumableResource>);
        }

        [Fact()]
        public void HealthResourcesTest()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void GenericsTest()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void HealthServicesTest()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void MapDataTest()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void SheltersTest()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void UsersTest()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void ConsumableTest()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void HealthResourceTest()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void GenericTest()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void HealthServiceTest()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void MapDataTest1()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void ShelterTest()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void UserTest()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void ConsumablesTest1()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void HealthResourcesTest1()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void GenericsTest1()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void HealthServicesTest1()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void MapDataTest2()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void SheltersTest1()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void UsersTest1()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void ConsumablesTest2()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void HealthResourcesTest2()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void GenericsTest2()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void HealthServicesTest2()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void MapDataTest3()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void SheltersTest2()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void UsersTest2()
        {
            Assert.True(false, "This test needs an implementation");
        }
    }
}