using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Housematica.Data.Data.CMS
{
    public class ProjectsContact
    {
        [Key]
        public int IdProjectsContact { get; set; }

        [Required]
        public string ContactPerson { get; set; }

        [Required]
        public string OwnerAdress { get; set; }


        [Required]
        public string OwnerPhone { get; set; }

        [Required]
        public string OwnerEmail { get; set; }

        [ForeignKey("Projects")]
        public Guid IdProjects { get; set; }

        [Required]
        public Projects Projects { get; set; }

    }
}
