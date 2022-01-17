using Housematica.Data.Data.CMS.Statistics;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Housematica.Data.Data.CMS
{
    public class ProjectsLicense
    { 
        [Key]
        public int IdProjectsLicens { get; set; }

    

        [ForeignKey("License")]
        public Guid IdLicense { get; set; }

        [ForeignKey("Projects")]
        public Guid IdProject { get; set; }

        [Required]
        public virtual License License { get; set;}

        [Required]
        public virtual Projects Projects { get; set; }



    }
}
