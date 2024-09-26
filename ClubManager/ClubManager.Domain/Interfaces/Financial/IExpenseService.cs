using ClubManager.Domain.DTOs.Financial;
using ClubManager.Domain.DTOs.Identity;
using ClubManager.Domain.Entities.Financial;
using ClubManager.Domain.Entities.Identity;

namespace ClubManager.Domain.Interfaces.Identity
{
    public interface IExpenseService
    {
        Task<Expense?> DeleteExpense(long id);
        Task<Expense> CreateExpense(ExpenseDTO expenseBody);
        Task<Expense> UpdateExpense(UpdateExpenseDTO expenseBody);
    }
}