using CompanyManagementApp.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        Task SaveChangesAsync();
    }
}
