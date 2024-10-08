using CompanyManagementApp.DAL.Repositories;
using CompanyManagementApp.Entities.Entities;

namespace CompanyManagementApp.BAL.Services
{
    public class ResumeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ResumeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // Tüm özgeçmişleri getir
        public async Task<IEnumerable<Resume>> GetAllResumesAsync()
        {
            return await _unitOfWork.Resumes.GetAllAsync();
        }

        // ID'ye göre özgeçmiş getir
        public async Task<Resume> GetResumeByIdAsync(int id)
        {
            return await _unitOfWork.Resumes.GetByIdAsync(id);
        }

        // Yeni özgeçmiş ekle
        public async Task AddResumeAsync(Resume resume)
        {
            await _unitOfWork.Resumes.AddAsync(resume);
            await _unitOfWork.SaveChangesAsync();
        }

        // Özgeçmişi güncelle
        public async Task UpdateResumeAsync(Resume resume)
        {
            await _unitOfWork.Resumes.UpdateAsync(resume);
            await _unitOfWork.SaveChangesAsync();
        }

        // Özgeçmişi sil
        public async Task DeleteResumeAsync(int id)
        {
            var resume = await _unitOfWork.Resumes.GetByIdAsync(id);
            if (resume != null)
            {
                await _unitOfWork.Resumes.DeleteAsync(resume);
                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}
