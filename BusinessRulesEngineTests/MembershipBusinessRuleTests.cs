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
    public class MembershipBusinessRuleTests : TestBase
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
            var sut = new MembershipBusinessRule(_mockRepository.Object);

            // Act
            Action act = () => sut.Execute(null);

            //Assert
            act.Should().ThrowExactly<ArgumentNullException>();
        }

        [Test]
        public void Given_A_Product_When_Execute_Is_Called_Adds_GST_To_Final_Price()
        {
            //arrange 
            var product = _fixture.Create<Membership>();
            product.Price = 100;
            product.IsUpgrade = false;
            var sut = new MembershipBusinessRule(_mockRepository.Object);
            _mockRepository.Setup(m => m.SendEmail()).Returns(Task.CompletedTask);
            _mockRepository.Setup(m => m.ActivateMembership()).Returns(Task.CompletedTask);

            // Act
            sut.Execute(product);

            //Assert
            product.FinalPrice.Should().Equals(105);
        }

        [Test]
        public void Given_A_Membership_Product_When_Execute_Is_Called_Calls_PartnerServices_Once()
        {
            //arrange 
            var product = _fixture.Create<Membership>();
            product.IsUpgrade = false;
            var sut = new MembershipBusinessRule(_mockRepository.Object);
            _mockRepository.Setup(m => m.SendEmail()).Returns(Task.CompletedTask);
            _mockRepository.Setup(m => m.ActivateMembership()).Returns(Task.CompletedTask);

            // Act
            sut.Execute(product);

            //Assert
            _mockRepository.Verify(m => m.ActivateMembership(), Times.Once);
            _mockRepository.Verify(m => m.SendEmail(), Times.Once);
        }

        [Test]
        public void Given_A_Upgrade_Membership_Product_When_Execute_Is_Called_Calls_PartnerServices_Twice()
        {
            //arrange 
            var product = _fixture.Create<Membership>();
            product.IsUpgrade = true;       
            var sut = new MembershipBusinessRule(_mockRepository.Object);
            _mockRepository.Setup(m => m.SendEmail()).Returns(Task.CompletedTask);
            _mockRepository.Setup(m => m.UpgradeMembership()).Returns(Task.CompletedTask);
            _mockRepository.Setup(m => m.ActivateMembership()).Returns(Task.CompletedTask);

            // Act
            sut.Execute(product);

            //Assert
            _mockRepository.Verify(m => m.SendEmail(), Times.Exactly(2));
        }
    }
}
