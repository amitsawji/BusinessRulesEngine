using AutoFixture;
using BusinessRulesEngine.BusinessRules;
using BusinessRulesEngine.Models;
using BusinessRulesEngine.PartnerService;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace BusinessRulesEngineTests
{
    public class VideoBusinessRulesTests: TestBase
    {
        private Mock<IPartnerService> _mockRepository;

        [SetUp]
        public void Setup()
        {
            _mockRepository = MockRepository.Create<IPartnerService>();
        }

        [TearDown]
        public void Teardown()
        {
            _mockRepository.VerifyAll();
        }

        [Test]
        public void Given_A_Product_Is_Null_When_Execute_Is_Called_Throws_ArgumentNullException()
        {
            //arrange 
            var sut = new VideoBusinessRules(_mockRepository.Object);

            // Act
            Action act = () => sut.Execute(null);

            //Assert
            act.Should().ThrowExactly<ArgumentNullException>();
        }

        [Test]
        public void Given_A_Product_When_Execute_Is_Called_Adds_GST_To_Final_Price()
        {
            //arrange 
            var product = _fixture.Create<Video>();
            product.Price = 100;
            var sut = new VideoBusinessRules(_mockRepository.Object);
            _mockRepository.Setup(m => m.GeneratePackingSlip()).Returns(Task.CompletedTask);

            // Act
            sut.Execute(product);

            //Assert
            product.FinalPrice.Should().Equals(120);
        }

        [Test]
        public void Given_A_Video_Product_When_Execute_Is_Called_Calls_PartnerServices_Once()
        {
            //arrange 
            var product = _fixture.Create<Video>();
            var sut = new VideoBusinessRules(_mockRepository.Object);
            _mockRepository.Setup(m => m.GeneratePackingSlip()).Returns(Task.CompletedTask);

            // Act
            sut.Execute(product);

            //Assert
            _mockRepository.Verify(m => m.GeneratePackingSlip(), Times.Once);
        }

        [Test]
        public void Given_A_Ski_Product_When_Execute_Is_Called_Calls_PartnerServices_Twice()
        {
            //arrange 
            var product = _fixture.Create<Video>();
            product.ProductName = "Learning To Ski";
            var sut = new VideoBusinessRules(_mockRepository.Object);
            _mockRepository.Setup(m => m.GeneratePackingSlip()).Returns(Task.CompletedTask);

            // Act
            sut.Execute(product);

            //Assert
            _mockRepository.Verify(m => m.GeneratePackingSlip(), Times.Exactly(2));
        }
    }
}
