using CleanArch.Domain.Entities;
using CleanArch.Domain.Validation;
using FluentAssertions;

namespace CleanArch.Domain.Test
{
    public class CategoryUnitTest1
    {
        [Fact]
        [Trait("Category", "Valid")]
        public void CreatCategory_WithValidParameters_ResultObejctValidState()
        {
            Action action = () => new Category(1, "Nome");
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        [Trait("Category", "id")]
        public void CreatCategory_NegativeValueId_DomainExceptionInvalidId()
        {
            Action action = () => new Category(-1, "Nome");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Id value");
        }

        [Fact]
        [Trait("Category", "name")]
        public void CreatCategory_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Category(1, "a");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Name invalid, Name need more 3 word");
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData(" ")]
        [Trait("Category", "Name")]
        public void CreatCategory_MissingNameValue_DomainExceptionMissingName(string name)
        {
            Action action = () => new Category(1, name);
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is requerid");
        }
    }
}