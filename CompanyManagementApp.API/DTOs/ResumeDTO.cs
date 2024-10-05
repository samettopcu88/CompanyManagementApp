namespace CompanyManagementApp.API.DTOs
{
    public class ResumeDTO
    {
        public int ResumeId { get; set; }
        public int EmployeeId { get; set; }
        public string Education { get; set; }
        public string Experience { get; set; }
        public string Skills { get; set; }
        public string Certifications { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
