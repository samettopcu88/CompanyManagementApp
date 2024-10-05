using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagementApp.Entities.Entities
{
    public class LeaveRequest
    {
        public int LeaveRequestId { get; set; }
        public int EmployeeId { get; set; }
        public string LeaveType { get; set; } // (örneğin: Rapor, Doğum, Mazeret, vb.)
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; } // (örneğin: Onay Bekliyor, Onaylandı, Reddedildi)
        public DateTime CreatedDate { get; set; }
        public Employee Employee { get; set; }
        public ICollection<Notification> Notifications { get; set; } // Notification ile ilişki
    }

}
