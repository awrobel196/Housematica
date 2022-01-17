using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Housematica.Data.Data.CMS
{
    public class ApartmentOption
    {
        [Key]
        public int IdApartmentOption { get; set; }

        public string OptionType { get; set; }
        public string OptionName { get; set; }
        public string OptionDescription { get; set; }
        public float Price { get; set; }


        [ForeignKey("Apartment")]
        public int IdApartment { get; set; }

        [Required]
        public virtual Apartment Apartment { get; set; }
    }
}
