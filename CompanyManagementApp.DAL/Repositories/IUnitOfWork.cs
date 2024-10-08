using CompanyManagementApp.Entities.Entities;
using Microsoft.AspNetCore.Identity;

namespace CompanyManagementApp.DAL.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Company> Companies { get; }
        IRepository<Employee> Employees { get; }
        IRepository<LeaveRequest> LeaveRequests { get; }
        IRepository<ExpenseRequest> ExpenseRequests { get; }
        IRepository<Notification> Notifications { get; }
        IRepository<Resume> Resumes { get; }
        UserManager<AppUser> UserManager { get; }
        RoleManager<AppRole> RoleManager { get; }
        IRepository<T> Repository<T>() where T : class;
        Task SaveChangesAsync();
    }
}
