namespace CompanyManagementApp.API.DTOs
{
    public class ExpenseRequestDTO
    {
        public int ExpenseRequestId { get; set; }
        public int EmployeeId { get; set; }
        public string ExpenseType { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
