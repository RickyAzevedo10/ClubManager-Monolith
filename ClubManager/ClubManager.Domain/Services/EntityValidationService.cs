using ClubManager.Domain.Interfaces;
using ClubManager.Domain.Services;
using FluentValidation;

namespace MSAuth.Domain.Services
{
    public class EntityValidationService : IEntityValidationService
    {
        private readonly ModelErrorsContext _modelErrorsContext;

        public EntityValidationService(ModelErrorsContext modelErrorContext)
        {
            _modelErrorsContext = modelErrorContext;
        }

        public bool Validate<T>(IValidator<T> validator, T entity)
        {
            var validationResult = validator.Validate(entity);
            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    _modelErrorsContext.AddModelError(typeof(T).Name, error.PropertyName, error.ErrorMessage);
                }
                return false;
            }
            return true;
        }
    }
}
