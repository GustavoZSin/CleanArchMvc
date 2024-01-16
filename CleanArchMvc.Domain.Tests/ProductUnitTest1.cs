using CleanArchMvc.Domain.Entities;
using FluentAssertions;

namespace CleanArchMvc.Domain.Tests
{
    public class ProductUnitTest1
    {
        [Fact]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, "product image");

            action.Should()
                .NotThrow<CleanArchMvc.Domain.Validations.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Product(-1, "Product Name", "Product Description", 9.99m, 99, "product image");

            action.Should()
                .Throw<CleanArchMvc.Domain.Validations.DomainExceptionValidation>()
                .WithMessage("Invalid Id Value");
        }

        [Fact]
        public void CreateProduct_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Product(1, "Pr", "Product Description", 9.99m, 99, "product image");

            action.Should()
                .Throw<CleanArchMvc.Domain.Validations.DomainExceptionValidation>()
                .WithMessage("Invalid name, too short, minimum 3 characters");
        }
        [Fact]
        public void CreateProduct_ShortDescriptionValue_DomainExceptionShortDescription()
        {
            Action action = () => new Product(1, "Production Name", "Prod", 9.99m, 99, "product image");

            action.Should()
                .Throw<CleanArchMvc.Domain.Validations.DomainExceptionValidation>()
                .WithMessage("Invalid description, too short, minimum 5 characters");
        }

        [Fact]
        public void CreateProduct_MissingNameValue_DomainExceptionRequiredName()
        {
            Action action = () => new Product(1, "", "Product Description", 9.99m, 99, "product image");

            action.Should()
                .Throw<CleanArchMvc.Domain.Validations.DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required");
        }
        [Fact]
        public void CreateProduct_WithNullNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Product(-1, null, "Product Description", 9.99m, 99, "product image");

            action.Should()
                .Throw<CleanArchMvc.Domain.Validations.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_MissingDescriptionValue_DomainExceptionRequiredDescription()
        {
            Action action = () => new Product(1, "Product Name", "", 9.99m, 99, "product image");

            action.Should()
                .Throw<CleanArchMvc.Domain.Validations.DomainExceptionValidation>()
                .WithMessage("Invalid description. Description is required");
        }
        [Fact]
        public void CreateProduct_WithNullDescriptionValue_DomainExceptionInvalidDescription()
        {
            Action action = () => new Product(1, "Product Name", null, 9.99m, 99, "product image");

            action.Should()
                .Throw<CleanArchMvc.Domain.Validations.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_NegativePriceValue_DomainExceptionInvalidPrice()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", -1m, 99, "product image");

            action.Should()
                .Throw<CleanArchMvc.Domain.Validations.DomainExceptionValidation>()
                .WithMessage("Invalid price value");
        }
        [Fact]
        public void CreateProduct_NegativeStockValue_DomainExceptionInvalidStock()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, -1, "product image");

            action.Should()
                .Throw<CleanArchMvc.Domain.Validations.DomainExceptionValidation>()
                .WithMessage("Invalid stock value");
        }

        [Fact]
        public void CreateProduct_WithNullImageNameValue_NoDomainException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, "");

            action.Should()
                .NotThrow<CleanArchMvc.Domain.Validations.DomainExceptionValidation>();
        }
        [Fact]
        public void CreateProduct_WithEmptyImageNameValue_NoDomainException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, null);

            action.Should()
                .NotThrow<CleanArchMvc.Domain.Validations.DomainExceptionValidation>();
        }
        [Fact]
        public void CreateProduct_WithEmptyImageNameValue_NoNullReferenceException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, null);

            action.Should()
                .NotThrow<NullReferenceException>();
        }
        public void CreateProduct_LongImageNameValue_DomainExceptionLongImageNameValue()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, "product image product image product image product image product image product image product image product image product image product image product image product image product image product image product image product image product image product image");

            action.Should()
                .Throw<CleanArchMvc.Domain.Validations.DomainExceptionValidation>()
                .WithMessage("Invalid image name, too long, maximum 250 characters");
        }
    }
}
