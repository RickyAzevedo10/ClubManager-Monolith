using ClubManager.Domain.DTOs.Financial;
using ClubManager.Domain.Entities.Financial;

namespace ClubManager.App.Services.Infrastructures
{
    public interface IExpenseAppService
    {
        Task<Expense?> DeleteExpense(long id);
        Task<List<Expense>?> CreateExpense(CreateExpenseDTO expenseBody);
        Task<List<Expense>?> UpdateExpense(UpdateEntityExpenseDTO expenseToUpdate);
        Task<Entity?> GetExpense(long expenseId);
        Task<List<Entity>?> GetAllExpense();
    }
}
