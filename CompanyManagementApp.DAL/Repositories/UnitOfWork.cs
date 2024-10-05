using CompanyManagementApp.DAL.Context;
using CompanyManagementApp.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagementApp.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        private IRepository<Company> _companies;
        private IRepository<Employee> _employees;
        private IRepository<LeaveRequest> _leaveRequests;
        private IRepository<ExpenseRequest> _expenseRequests;
        private IRepository<Notification> _notifications;
        private IRepository<Resume> _resumes;

        public IRepository<Company> Companies => _companies ??= new Repository<Company>(_context);
        public IRepository<Employee> Employees => _employees ??= new Repository<Employee>(_context);
        public IRepository<LeaveRequest> LeaveRequests => _leaveRequests ??= new Repository<LeaveRequest>(_context);
        public IRepository<ExpenseRequest> ExpenseRequests => _expenseRequests ??= new Repository<ExpenseRequest>(_context);
        public IRepository<Notification> Notifications => _notifications ??= new Repository<Notification>(_context);
        public IRepository<Resume> Resumes => _resumes ??= new Repository<Resume>(_context);

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
