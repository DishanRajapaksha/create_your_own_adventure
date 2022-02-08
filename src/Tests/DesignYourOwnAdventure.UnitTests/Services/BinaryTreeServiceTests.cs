using DesignYourOwnAdventure.Core.Entities;
using DesignYourOwnAdventure.Core.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using DesignYourOwnAdventure.Core.Models;

namespace DesignYourOwnAdventure.UnitTests.Services
{
    [TestClass]
    public class BinaryTreeServiceTests
    {
        [TestInitialize]
        public void TestInitialize()
        {
         }

        private BinaryTreeService CreateService()
        {
            return new BinaryTreeService();
        }

        [TestMethod]
        public void BuildTree_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            BinaryTreeService? service = CreateService();
            CreateAdventureRequest request = null;

            // Act
            BinaryTree<Question>? result = service.BuildTree(
                request);

            // Assert
            Assert.Fail();
            // mockRepository.VerifyAll();
        }

        [TestMethod]
        public void Traverse_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            BinaryTreeService? service = CreateService();
            // BinaryTree tree = null;
            // List steps = null;

            // Act
            //List<AnswerResponse>? result = service.Traverse(
            //    tree,
            //    steps);

            // Assert
            Assert.Fail();
        }
    }
}
