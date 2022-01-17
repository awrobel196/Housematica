using Housematica.Data.Data.CMS;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Housematica.Data.Data.CMS
{
    public class License
    {
        [Key]
        public Guid IdLicense { get; set; }

        [ForeignKey("LicenseType")]
        public int IdLicenseType { get; set; }
        public DateTime Expire { get; set; }
        public List<User> User { get; set; }
        public List<ProjectsLicense> ProjectsLicense { get; set; }
        public virtual LicenseType LicenseType { get; set; }


    }
}
