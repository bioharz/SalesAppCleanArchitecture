using CleanArchitecture.Domain.Entities;
using FluentValidation;

namespace CleanArchitecture.Application.SaleItems.Commands.CreateSaleItem
{
    public class CreateSaleItemCommandValidator : AbstractValidator<CreateSaleItemCommand>
    {
        public CreateSaleItemCommandValidator()
        {
            RuleFor(v => v.ArticleNumber)
                .MaximumLength(SaleItemConstants.ArticleNumberMaxLength)
                .NotEmpty();
        }
    }
}
