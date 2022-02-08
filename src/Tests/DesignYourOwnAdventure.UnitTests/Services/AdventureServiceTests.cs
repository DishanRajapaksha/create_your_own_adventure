using DesignYourOwnAdventure.Core.Entities;
using DesignYourOwnAdventure.Core.Interfaces;
using DesignYourOwnAdventure.Core.Models;
using DesignYourOwnAdventure.Core.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesignYourOwnAdventure.UnitTests.Services
{
    [TestClass]
    public class AdventureServiceTests
    {
        private MockRepository mockRepository;

        private Mock<IBinaryTreeService> mockBinaryTreeService;
        private Mock<IRepository<BinaryTree<Question>>> mockRepositoryBinaryTreeQuestion;
        private Mock<IRepository<Answer?>> mockRepositoryAnswer;

        [TestInitialize]
        public void TestInitialize()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);

            mockBinaryTreeService = mockRepository.Create<IBinaryTreeService>();
            mockRepositoryBinaryTreeQuestion = mockRepository.Create<IRepository<BinaryTree<Question>>>();
            mockRepositoryAnswer = mockRepository.Create<IRepository<Answer?>>();
        }

        private AdventureService CreateService()
        {
            return new AdventureService(
                mockBinaryTreeService.Object,
                mockRepositoryBinaryTreeQuestion.Object,
                mockRepositoryAnswer?.Object);
        }

        [TestMethod]
        public async Task Create_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            AdventureService? service = CreateService();
            CreateAdventureRequest request = null;

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
            AdventureService? service = CreateService();

            // Act
            List<BinaryTree<Question>>? result = await service.Read();

            // Assert
            Assert.Fail();
            mockRepository.VerifyAll();
        }

        [TestMethod]
        public async Task Read_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            AdventureService? service = CreateService();
            int id = 0;

            // Act
            BinaryTree<Question>? result = await service.Read(
                id);

            // Assert
            Assert.Fail();
            mockRepository.VerifyAll();
        }
    }
}
