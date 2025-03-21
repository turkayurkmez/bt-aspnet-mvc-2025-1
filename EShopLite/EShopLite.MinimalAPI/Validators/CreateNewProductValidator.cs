using EShopLite.Application.DataTransferObjects;
using FluentValidation;

namespace EShopLite.MinimalAPI.Validators
{
    public class CreateNewProductValidator : AbstractValidator<CreateNewProductRequest>
    {
        public CreateNewProductValidator() 
        {
            RuleFor(x => x.Name)
                   .NotEmpty().WithMessage("Ürün adı boş olamaz")
                   .MinimumLength(3).WithMessage("Ürün adı en az 3 haef içermeli")
                   .MaximumLength(100).WithMessage("Ürün adı en çok 100 karakter içermeli");
                
        }
    }
}
