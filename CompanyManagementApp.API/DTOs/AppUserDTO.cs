namespace CompanyManagementApp.API.DTOs
{
    public class AppUserDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public int EmployeeId { get; set; } // Employee ile ilişkili
    }
}
