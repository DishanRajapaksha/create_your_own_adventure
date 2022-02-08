using DesignYourOwnAdventure.Core.Entities;
using DesignYourOwnAdventure.Core.Interfaces;
using DesignYourOwnAdventure.Core.Services;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesignYourOwnAdventure.UnitTests.Services
{
    [TestClass]
    public class UserServiceTests
    {
        private MockRepository mockRepository;

        private Mock<ILogger<IRepository<User>>> mockLogger;
        private Mock<IRepository<User>> mockUserRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);

            mockLogger = mockRepository.Create<ILogger<IRepository<User>>>();
           // mockUserRepository = mockUserRepository.Create<IRepository<User>>();
        }

        private UserService CreateService()
        {
            return new UserService(
                mockLogger.Object,
                mockUserRepository.Object);
        }

        [TestMethod]
        public async Task Create_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            UserService? service = CreateService();
            User request = null;

            // Act
            int result = await service.Create(
                request);

            // Assert
            Assert.Fail();
            mockRepository.VerifyAll();
        }

        [TestMethod]
        public async Task Read_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            UserService? service = CreateService();

            // Act
            List<User>? result = await service.Read();

            // Assert
            Assert.Fail();
            mockRepository.VerifyAll();
        }

        [TestMethod]
        public async Task Read_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            UserService? service = CreateService();
            int id = 0;

            // Act
            User? result = await service.Read(
                id);

            // Assert
            Assert.Fail();
            mockRepository.VerifyAll();
        }
    }
}
