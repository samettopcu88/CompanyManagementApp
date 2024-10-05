using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagementApp.Entities.Entities
{
    public class AppUser : IdentityUser<int> // Primary Key türü olarak int kullandık
    {
        // IdentityUser'dan gelen özelliklere ek olarak ihtiyaç duyduğun özellikleri ekleyebilirsin
        public bool IsActive { get; set; }
        public Employee Employee { get; set; } // Employee ile ilişki
    }
}
