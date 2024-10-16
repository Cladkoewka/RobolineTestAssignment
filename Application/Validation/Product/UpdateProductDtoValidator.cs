using Application.DTOs.Product;
using FluentValidation;

namespace Application.Validation.Product;

public class UpdateProductDtoValidator : AbstractValidator<UpdateProductDto>
{
    public UpdateProductDtoValidator()
    {
        RuleFor(product => product.Name)
            .NotEmpty().WithMessage("Name is required")
            .Length(2, 100).WithMessage("Name length must be between 2 and 100");
        
        RuleFor(product => product.Description)
            .NotEmpty().WithMessage("Description is required")
            .MaximumLength(100).WithMessage("Description max length is 500");

        RuleFor(product => product.Price)
            .NotEmpty().WithMessage("Price is required")
            .GreaterThan(0).WithMessage("Price must be greater than 0");
        
        RuleFor(product => product.CategoryId)
            .NotEmpty().WithMessage("Category Id is required");
    }
}