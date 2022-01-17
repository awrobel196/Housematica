using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Housematica.Data.Data.CMS
{
    public class Apartment
    {
        [Key]
        public int IdApartment { get; set; }
        public string ApartmentName { get; set; }
        public float Area { get; set; }
        public string Floor { get; set; }
        public string Status { get; set; }

        [ForeignKey("Projects")]
        public Guid IdProjects { get; set; }

        [Required]
        public virtual Projects Projects { get; set; }

        public virtual List<ApartmentVariants> ApartmentVariants { get; set; }

        public virtual List<ApartmentOption> ApartmentOption { get; set; }




    }
}
