using CleanArch.Domain.Entities;
using CleanArch.Domain.Validation;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Test
{
    public class ProductUnitTest1
    {
        [Fact]
        [Trait("Product", "Valid")]
        public void CreatCategory_WithValidParameters_ResultObejctValidState()
        {
            Action action = () => new Product(1, "Conrado", "Mouse", 9.99m, 99, "Image");
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        [Trait("Product", "Name")]
        public void CreatCategory_NegativeIdValue_ResultObejctNegativeId()
        {
            Action action = () => new Product(-1, "Conrado", "Mouse", 9.99m, 99, "Image");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Id value");
        }
        
        [Fact]
        [Trait("Product", "Id")]
        public void CreatCategory_TooShortNameValue_ResultObejctTooShortName()
        {
            Action action = () => new Product(1, "C", "Mouse", 9.99m, 99, "Image");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Name invalid, Name need more 3 word");
        }

        [Fact]
        [Trait("Product", "Image")]
        public void CreatCategory_TooLongImageValue_ResultObejctTooLongImage()
        {
            const string fictinalName = "Conrado Vincoletto Conrado Vincoletto Conrado Vincoletto Conrado " +
                "Vincoletto Conrado Vincoletto Conrado Vincoletto  Conrado Vincoletto  Conrado Vincoletto  Conrado Vincoletto  " +
                "Conrado Vincoletto Conrado Vincoletto Conrado Vincoletto Conrado Vincoletto Conrado Vincoletto";

            Action action = () => new Product(1, "Conrado", "Mouse", 9.99m, 99, fictinalName);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Image too long. Image need be less of 250 characters");
        }

        [Theory]
        [InlineData(" ")]
        [InlineData(null)]
        [Trait("Product", "Id")]
        public void CreatCategory_WithiNullOrEmptyImage_ResultObejctWithNullOrEmptyImage(string image)
        {
            Action action = () => new Product(1, "Conrado", "Mouse", 9.99m, 99, image);
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        [Trait("Product", "Stock")]
        public void CreatCategory_InvalidStockValue_ResultObejctNegativeStockValue()
        {
            Action action = () => new Product(1, "Conrado", "Mouse", 9.99m, -1, "Image");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid stock value");
        }

        [Fact]
        [Trait("Product", "Stock")]
        public void CreatCategory_InvalidPriceValue_ResultObejctNegativePriceValue()
        {
            Action action = () => new Product("Conrado", "Mouse", -1, 99, "Image");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid price value");
        }
    }
}
