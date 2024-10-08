using CompanyManagementApp.DAL.Repositories;
using CompanyManagementApp.Entities.Entities;

namespace CompanyManagementApp.BAL.Services
{
    public class LeaveRequestService
    {
        private readonly IUnitOfWork _unitOfWork;

        public LeaveRequestService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // Tüm izin taleplerini getir
        public async Task<IEnumerable<LeaveRequest>> GetAllLeaveRequestsAsync()
        {
            return await _unitOfWork.LeaveRequests.GetAllAsync();
        }

        // ID'ye göre izin talebi getir
        public async Task<LeaveRequest> GetLeaveRequestByIdAsync(int id)
        {
            return await _unitOfWork.LeaveRequests.GetByIdAsync(id);
        }

        // Yeni izin talebi ekle
        public async Task AddLeaveRequestAsync(LeaveRequest leaveRequest)
        {
            await _unitOfWork.LeaveRequests.AddAsync(leaveRequest);
            await _unitOfWork.SaveChangesAsync();
        }

        // İzin talebini güncelle
        public async Task UpdateLeaveRequestAsync(LeaveRequest leaveRequest)
        {
            await _unitOfWork.LeaveRequests.UpdateAsync(leaveRequest);
            await _unitOfWork.SaveChangesAsync();
        }

        // İzin talebini sil
        public async Task DeleteLeaveRequestAsync(int id)
        {
            var leaveRequest = await _unitOfWork.LeaveRequests.GetByIdAsync(id);
            if (leaveRequest != null)
            {
                await _unitOfWork.LeaveRequests.DeleteAsync(leaveRequest);
                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}
