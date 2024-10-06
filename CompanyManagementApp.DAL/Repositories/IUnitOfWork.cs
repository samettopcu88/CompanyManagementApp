using CompanyManagementApp.Entities.Entities;

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
        IRepository<T> Repository<T>() where T : class;
        Task SaveChangesAsync();
    }
}
