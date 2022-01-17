using Housematica.Data.Data.CMS.Statistics;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Housematica.Data.Data.CMS
{
    public class Projects
    {
        [Key]
        public Guid IdProject { get; set; }

        [Required]
        public string OwnerName { get; set; }


        [Required]
        public string ProjectAdress1 { get; set; }

      
        public string ProjectAdress2 { get; set; }

        [Required]
        public string ProjectPostcode { get; set; }

        [Required]
        public string ProjectCity { get; set; }

        [Required]
        public string ProjectState { get; set; }

        [Required]
        public string ProjectCountry { get; set; }

        [Required]
        public string ProjectName { get; set; }

        [Required]
        public string ProjectDescription { get; set; }

        [ForeignKey("ProjectType")]
        public int IdProjectType { get; set; }


        //Sprawdza czy projekt jest aktywowany
        public bool IsActive { get; set; }

        //Sprawdza czy projekt jest usunięty
        public bool IsDelete { get; set; }

        //Sprawdza czy projekt jest zwalidowany i zaakceptowany przez administratora
        public bool IsValidate { get; set; }

        [Required]
        public virtual ProjectType ProjectType { get; set; }

        [Required]
        public ProjectsContact ProjectsContact { get; set; }

        public Views Views { get; set; }
        public UViews UViews { get; set; }

        public TotalConfiguration TotalConfiguration { get; set; }

        public virtual List<Apartment> Apartment { get; set; }

        public virtual List<Single> Single { get; set; }

        public virtual List<House> House { get; set; }

        public virtual List<ProjectsUser> ProjectsUser { get; set; }

        public virtual List<ProjectsLicense> ProjectsLicense { get; set; }


    }
}
