using Application.DTOs.ProductCategory;
using FluentValidation;

namespace Application.Validation.ProductCategory;

public class CreateProductCategoryDtoValidator : AbstractValidator<CreateProductCategoryDto>
{
    public CreateProductCategoryDtoValidator()
    {
        RuleFor(category => category.Name)
            .NotEmpty().WithMessage("Name is required")
            .Length(2, 100).WithMessage("Name length must be between 2 and 100");
    }
}