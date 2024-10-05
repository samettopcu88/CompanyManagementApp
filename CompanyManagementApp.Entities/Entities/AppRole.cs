using Microsoft.AspNetCore.Identity;

namespace CompanyManagementApp.Entities.Entities
{
    public class AppRole : IdentityRole<int> // Primary Key türü olarak int kullandık
    {
        public string RoleDescription { get; set; }
        public ICollection<AppUser> Users { get; set; }
    }
}
