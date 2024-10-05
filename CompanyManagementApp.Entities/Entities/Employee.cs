using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagementApp.Entities.Entities
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int CompanyId { get; set; }
        public int UserId { get; set; }
        public bool IsActive { get; set; }
        public AppUser User { get; set; } // User ile ilişki
        public Company Company { get; set; }
        public ICollection<LeaveRequest> LeaveRequests { get; set; } // LeaveRequest ile ilişki
        public ICollection<ExpenseRequest> ExpenseRequests { get; set; } // ExpenseRequest ile ilişki
        public Resume Resume { get; set; } // Resume ile ilişki
    }

}
