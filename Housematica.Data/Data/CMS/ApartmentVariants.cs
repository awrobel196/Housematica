using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Housematica.Data.Data.CMS
{
    public class ApartmentVariants
    {
        [Key]
        public int IdApartmentVariants { get; set; }
        public float ApartmentArea { get; set; }
        public float BalconyArea { get; set; }
        public int NumberOfLivingRoom { get; set; }
        public float ApartmentPrice { get; set; }

        public string ApartmentModel { get; set; }

        [ForeignKey("Apartment")]
        public int IdApartment { get; set; }

        [Required]
        public virtual Apartment Apartment { get; set; }

        public virtual List<Rooms> Rooms { get; set;  }
    }
}
