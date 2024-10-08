using CompanyManagementApp.DAL.Repositories;
using CompanyManagementApp.Entities.Entities;

namespace CompanyManagementApp.BAL.Services
{
    public class CompanyService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompanyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // Tüm şirketleri getir
        public async Task<IEnumerable<Company>> GetAllCompaniesAsync()
        {
            return await _unitOfWork.Companies.GetAllAsync();
        }

        // ID'ye göre bir şirket getir
        public async Task<Company> GetCompanyByIdAsync(int id)
        {
            return await _unitOfWork.Companies.GetByIdAsync(id);
        }

        // Yeni şirket ekle
        public async Task AddCompanyAsync(Company company)
        {
            await _unitOfWork.Companies.AddAsync(company);
            await _unitOfWork.SaveChangesAsync();
        }

        // Şirketi güncelle
        public async Task UpdateCompanyAsync(Company company)
        {
            await _unitOfWork.Companies.UpdateAsync(company);
            await _unitOfWork.SaveChangesAsync();
        }

        // Şirketi sil
        public async Task DeleteCompanyAsync(int id)
        {
            var company = await _unitOfWork.Companies.GetByIdAsync(id);
            if (company != null)
            {
                await _unitOfWork.Companies.DeleteAsync(company);
                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}
