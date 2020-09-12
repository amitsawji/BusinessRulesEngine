using AutoFixture;
using BusinessRulesEngine.BusinessRules;
using BusinessRulesEngine.Models;
using FluentAssertions;
using NUnit.Framework;
using System;


namespace BusinessRulesEngineTests
{
    public class BookBusinessRulesTest : TestBase
    {
        [Test]
        public void Given_A_Product_Is_Null_When_Execute_Is_Called_Throws_ArgumentNullException()
        {
            //arrange 
            var sut = new BookBusinessRule();

            // Act
            Action act = () => sut.Execute(null);

            //Assert
            act.Should().ThrowExactly<ArgumentNullException>();
        }

        [Test]
        public void Given_A_Product_When_Execute_Is_Called_Adds_GST_To_Final_Price()
        {
            //arrange 
            var product = _fixture.Create<Book>();
            product.Price = 50;
            var sut = new BookBusinessRule();

            // Act
            sut.Execute(product);

            //Assert
            product.FinalPrice.Should().Equals(56);
        }
    }
}
