using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagementApp.Entities.Entities
{
    public class ExpenseRequest
    {
        public int ExpenseRequestId { get; set; }
        public int EmployeeId { get; set; }
        public string ExpenseType { get; set; } // (örneğin: Yol, Konaklama, Yemek, vb.)
        public decimal Amount { get; set; }
        public string Status { get; set; } // (örneğin: Onay Bekliyor, Onaylandı, Reddedildi)
        public DateTime CreatedDate { get; set; }
        public Employee Employee { get; set; }
        public ICollection<Notification> Notifications { get; set; } // Notification ile ilişki
    }

}
