namespace ClubManager.Domain.Interfaces
{
    public interface IModelErrorsContext
    {
        void AddModelError(string model, string field, string message);
        bool HasErrors();
        bool HasModelError(string model);
    }
}
