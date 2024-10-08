using CompanyManagementApp.DAL.Repositories;
using CompanyManagementApp.Entities.Entities;

namespace CompanyManagementApp.BAL.Services
{
    public class ExpenseRequestService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ExpenseRequestService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // Tüm masraf taleplerini getir
        public async Task<IEnumerable<ExpenseRequest>> GetAllExpenseRequestsAsync()
        {
            return await _unitOfWork.ExpenseRequests.GetAllAsync();
        }

        // ID'ye göre masraf talebi getir
        public async Task<ExpenseRequest> GetExpenseRequestByIdAsync(int id)
        {
            return await _unitOfWork.ExpenseRequests.GetByIdAsync(id);
        }

        // Yeni masraf talebi ekle
        public async Task AddExpenseRequestAsync(ExpenseRequest expenseRequest)
        {
            await _unitOfWork.ExpenseRequests.AddAsync(expenseRequest);
            await _unitOfWork.SaveChangesAsync();
        }

        // Masraf talebini güncelle
        public async Task UpdateExpenseRequestAsync(ExpenseRequest expenseRequest)
        {
            await _unitOfWork.ExpenseRequests.UpdateAsync(expenseRequest);
            await _unitOfWork.SaveChangesAsync();
        }

        // Masraf talebini sil
        public async Task DeleteExpenseRequestAsync(int id)
        {
            var expenseRequest = await _unitOfWork.ExpenseRequests.GetByIdAsync(id);
            if (expenseRequest != null)
            {
                await _unitOfWork.ExpenseRequests.DeleteAsync(expenseRequest);
                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}
