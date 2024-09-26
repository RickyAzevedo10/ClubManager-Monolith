using ClubManager.Domain.DTOs.Financial;
using ClubManager.Domain.Entities.Financial;

namespace ClubManager.App.Services.Infrastructures
{
    public interface IExpenseAppService
    {
        Task<ExpenseResponseDTO?> DeleteExpense(long id);
        Task<ExpenseResponseDTO?> CreateExpense(ExpenseDTO expenseBody);
        Task<ExpenseResponseDTO?> UpdateExpense(UpdateExpenseDTO expenseToUpdate);
        Task<ExpenseResponseDTO?> GetExpense(long expenseId);
        Task<List<ExpenseResponseDTO>?> GetAllExpense();
    }
}
