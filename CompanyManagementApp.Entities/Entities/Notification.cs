using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagementApp.Entities.Entities
{
    public class Notification
    {
        public int NotificationId { get; set; }
        public int UserId { get; set; } // Foreign Key to User
        public string Message { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? LeaveRequestId { get; set; } // Foreign Key to LeaveRequest (isteğe bağlı)
        public LeaveRequest LeaveRequest { get; set; } // LeaveRequest ile ilişki
        public int? ExpenseRequestId { get; set; } // Foreign Key to ExpenseRequest (isteğe bağlı)
        public ExpenseRequest ExpenseRequest { get; set; } // ExpenseRequest ile ilişki


    }

}
