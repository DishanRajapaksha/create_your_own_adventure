using DesignYourOwnAdventure.Core.Entities;
using DesignYourOwnAdventure.Core.Interfaces;
using DesignYourOwnAdventure.Core.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using DesignYourOwnAdventure.Core.Models;

namespace DesignYourOwnAdventure.UnitTests.Services
{
    [TestClass]
    public class AnswerServiceTests
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

        private AnswerService CreateService()
        {
            return new AnswerService(
                mockBinaryTreeService.Object,
                mockRepositoryBinaryTreeQuestion.Object,
                mockRepositoryAnswer?.Object);
        }

        [TestMethod]
        public async Task Read_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            AnswerService? service = CreateService();
            int answerId = 0;

            // Act
            Answer? result = await service.Read(
                answerId);

            // Assert
            Assert.Fail();
            mockRepository.VerifyAll();
        }

        [TestMethod]
        public async Task Traverse_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            AnswerService? service = CreateService();
            int id = 0;

            // Act
            List<AnswerResponse>? result = await service.Traverse(
                id);

            // Assert
            Assert.Fail();
            mockRepository.VerifyAll();
        }

        [TestMethod]
        public async Task Read_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            AnswerService? service = CreateService();

            // Act
            List<Answer?>? result = await service.Read();

            // Assert
            Assert.Fail();
            mockRepository.VerifyAll();
        }

        [TestMethod]
        public async Task Create_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            AnswerService? service = CreateService();
            int userId = 0;
            int adventureId = 0;
            //List steps = null;

            // Act
            //int result = await service.Create(
            //    userId,
            //    adventureId,
            //    steps);

            // Assert
            Assert.Fail();
            mockRepository.VerifyAll();
        }
    }
}
