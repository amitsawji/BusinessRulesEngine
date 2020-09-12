using AutoFixture;
using BusinessRulesEngine.BusinessRules;
using BusinessRulesEngine.Models;
using FluentAssertions;
using NUnit.Framework;
using System;

namespace BusinessRulesEngineTests
{
    public class PhysicalProductRuleTests : TestBase
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Given_A_Product_When_()
        {
            //arrange 
            var product = _fixture.Create<PhysicalProduct>();
            var sut = new PhysicalProductRule();

            // Act
            Action act = () => sut.Execute(product);

            //Assert
            act.Should().ThrowExactly<NotImplementedException>();
        }
    }
}