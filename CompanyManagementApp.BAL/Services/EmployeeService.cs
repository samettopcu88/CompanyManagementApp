using CompanyManagementApp.DAL.Repositories;
using CompanyManagementApp.Entities.Entities;

namespace CompanyManagementApp.BAL.Services
{
    public class EmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // Tüm çalışanları getir
        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _unitOfWork.Employees.GetAllAsync();
        }

        // ID'ye göre çalışan getir
        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _unitOfWork.Employees.GetByIdAsync(id);
        }

        // Yeni çalışan ekle
        public async Task AddEmployeeAsync(Employee employee)
        {
            await _unitOfWork.Employees.AddAsync(employee);
            await _unitOfWork.SaveChangesAsync();
        }

        // Çalışanı güncelle
        public async Task UpdateEmployeeAsync(Employee employee)
        {
            await _unitOfWork.Employees.UpdateAsync(employee);
            await _unitOfWork.SaveChangesAsync();
        }

        // Çalışanı sil
        public async Task DeleteEmployeeAsync(int id)
        {
            var employee = await _unitOfWork.Employees.GetByIdAsync(id);
            if (employee != null)
            {
                await _unitOfWork.Employees.DeleteAsync(employee);
                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}
