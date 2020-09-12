using AutoFixture;
using BusinessRulesEngine.BusinessRules;
using BusinessRulesEngine.Models;
using BusinessRulesEngine.PartnerService;
using BusinessRulesEngine.PaymentStrategy;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessRulesEngineTests
{
    public class PaymentStrategyTests : TestBase
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
        public void Given_A_Product_Is_Ordered_When_Product_Exists_Then_ProcessPayment_Successfully()
        {
            //arrange 
            var physicalRule = new PhysicalProductRule(_mockRepository.Object);
            _mockRepository.Setup(m => m.GeneratePackingSlip()).Returns(Task.CompletedTask);
            _mockRepository.Setup(m => m.GenerateCommision()).Returns(Task.CompletedTask);
            var _businessRules = new List<IProductBusinessRule>();
            _businessRules.Add(physicalRule);
           
            var product = _fixture.Create<PhysicalProduct>();
            var sut = new PaymentStrategy(_businessRules);

            // Act
            Action act = () => sut.ProcessPayment(product);

            //Assert
            act.Should().NotThrow();
        }

        [Test]
        public void Given_A_Product_Is_Null_When_MakePayment_Is_Called_Then_Throws_ArgumentNullException()
        {
            //arrange 
            var physicalRule = new PhysicalProductRule(_mockRepository.Object);
            var _businessRules = new List<IProductBusinessRule>();
            _businessRules.Add(physicalRule);

            var product = _fixture.Create<Book>();
            product.ProductType = ProductType.Book;
            var sut = new PaymentStrategy(_businessRules);

            // Act
            Action act = () => sut.ProcessPayment(product);

            //Assert
            act.Should().ThrowExactly<ArgumentNullException>();
        }
    }
}
