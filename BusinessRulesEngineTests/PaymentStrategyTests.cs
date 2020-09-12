using AutoFixture;
using BusinessRulesEngine.BusinessRules;
using BusinessRulesEngine.Models;
using BusinessRulesEngine.PaymentStrategy;
using FluentAssertions;
using NUnit.Framework;
using System;

namespace BusinessRulesEngineTests
{
    public class PaymentStrategyTests : TestBase
    {
        [Test]
        public void Given_A_Product_Is_Ordered_When_No_Product_Exists_Then_Throws_ArgumentNullException()
        {
            //arrange 
            var rules = _fixture.CreateMany<PhysicalProductRule>();
            var product = _fixture.Create<Book>();
            product.ProductType = ProductType.Book;
            var sut = new PaymentStrategy(rules);

            // Act
            Action act = () => sut.ProcessPayment(product);

            //Assert
            act.Should().ThrowExactly<ArgumentNullException>();
        }
    }
}
