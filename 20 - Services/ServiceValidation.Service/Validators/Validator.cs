using System.Linq;
using FluentValidation;
using ValidationException = ServiceValidation.Core.Exceptions.ValidationException;

namespace ServiceValidation.Service.Validators
{
    public static class Validator
    {
        /// <summary>
        /// Valide une entité et lance une exception dans le cas où la validation échouerait.
        /// </summary>
        /// <typeparam name="TValidator">Classe Validator contenant les règles</typeparam>
        /// <typeparam name="TEntity">Type de l'entité à valider</typeparam>
        /// <param name="entity">Entité à valider</param>
        public static void Validate<TValidator, TEntity>(TEntity entity) where TValidator : AbstractValidator<TEntity>, new()
        {
            var validator = new TValidator();
            var validationResult = validator.Validate(entity);

            if (!validationResult.IsValid)
            {
                var validationDictionary = validationResult.Errors.ToDictionary(v => v.PropertyName, v => v.ErrorMessage);
                throw new ValidationException(validationDictionary);
            }
        }
    }
}