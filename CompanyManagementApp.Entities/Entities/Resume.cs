using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagementApp.Entities.Entities
{
    public class Resume
    {
        public int ResumeId { get; set; }
        public int EmployeeId { get; set; }
        public string Education { get; set; } // Eğitim bilgileri
        public string Experience { get; set; } // İş deneyimleri
        public string Skills { get; set; } // Yetenekler
        public string Certifications { get; set; } // Sertifikalar
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Employee Employee { get; set; } // Employee ile ilişki

    }

}
