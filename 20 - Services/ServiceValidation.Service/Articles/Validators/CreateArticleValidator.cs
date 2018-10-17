using FluentValidation;
using ServiceValidation.Service.Articles.Commands;

namespace ServiceValidation.Service.Articles.Validators
{
    public class CreateArticleValidator : AbstractValidator<CreateArticle>
    {
        public CreateArticleValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("Le nom doit être rempli");

            RuleFor(c => c.Description)
                .NotEmpty()
                .WithMessage("La description doit être remplie");
        }
    }
}