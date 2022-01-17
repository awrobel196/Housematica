using Housematica.Data.Data.CMS.Statistics;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Housematica.Data.Data.CMS
{
    public class ProjectsUser
    {
        [Key]
        public int IdProjectsUser { get; set; }



        [ForeignKey("User")]
        public Guid IdUser { get; set; }

        [ForeignKey("Projects")]
        public Guid IdProject { get; set; }

        [Required]
        public virtual User User { get; set; }

        [Required]
        public virtual Projects Projects { get; set; }



    }
}
