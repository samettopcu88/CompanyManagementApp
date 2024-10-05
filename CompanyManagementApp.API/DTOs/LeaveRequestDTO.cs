namespace CompanyManagementApp.API.DTOs
{
    public class LeaveRequestDTO
    {
        public int LeaveRequestId { get; set; }
        public int EmployeeId { get; set; }
        public string LeaveType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
