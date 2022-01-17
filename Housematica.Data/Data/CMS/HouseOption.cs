using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Housematica.Data.Data.CMS
{
    public class HouseOption
    {
        [Key]
        public int IdHouseOption { get; set; }

        public string OptionType { get; set; }
        public string OptionName { get; set; }
        public string OptionDescription { get; set; }
        public float Price { get; set; }


        [ForeignKey("House")]
        public int IdHouse { get; set; }

        [Required]
        public virtual House House { get; set; }
    }
}
