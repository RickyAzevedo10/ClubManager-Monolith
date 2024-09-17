using ClubManager.Domain.Common.ModelErrors;

namespace ClubManager.Domain.Interfaces
{
    public interface IModelErrorsContext
    {
        void AddModelError(string model, string field, string message);
        bool HasErrors();
        IReadOnlyCollection<ModelErrors> ModelErrors { get; }
        bool HasModelError(string model);
    }
}
