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
        public void Given_A_Product_Is_Null_When_Execute_Is_Called_Throws_ArgumentNullException()
        {
            //arrange 
            var sut = new PhysicalProductRule();

            // Act
            Action act = () => sut.Execute(null);

            //Assert
            act.Should().ThrowExactly<ArgumentNullException>();
        }

        [Test]
        public void Given_A_Product_When_Execute_Is_Called_Adds_GST_To_Final_Price()
        {
            //arrange 
            var product = _fixture.Create<PhysicalProduct>();
            product.Price = 100;
            var sut = new PhysicalProductRule();

            // Act
            sut.Execute(product);

            //Assert
            product.FinalPrice.Should().Equals(120);
        }
    }
}