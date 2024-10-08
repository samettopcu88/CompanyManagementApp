using CompanyManagementApp.DAL.Repositories;
using CompanyManagementApp.Entities.Entities;

namespace CompanyManagementApp.BAL.Services
{
    public class NotificationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public NotificationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // Tüm bildirimleri getir
        public async Task<IEnumerable<Notification>> GetAllNotificationsAsync()
        {
            return await _unitOfWork.Notifications.GetAllAsync();
        }

        // ID'ye göre bildirim getir
        public async Task<Notification> GetNotificationByIdAsync(int id)
        {
            return await _unitOfWork.Notifications.GetByIdAsync(id);
        }

        // Yeni bildirim ekle
        public async Task AddNotificationAsync(Notification notification)
        {
            await _unitOfWork.Notifications.AddAsync(notification);
            await _unitOfWork.SaveChangesAsync();
        }

        // Bildirimi güncelle
        public async Task UpdateNotificationAsync(Notification notification)
        {
            await _unitOfWork.Notifications.UpdateAsync(notification);
            await _unitOfWork.SaveChangesAsync();
        }

        // Bildirimi sil
        public async Task DeleteNotificationAsync(int id)
        {
            var notification = await _unitOfWork.Notifications.GetByIdAsync(id);
            if (notification != null)
            {
                await _unitOfWork.Notifications.DeleteAsync(notification);
                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}
