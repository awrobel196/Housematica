using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Housematica.Data.Data.CMS
{
    public class HouseVariants
    {
        [Key]
        public int IdHouseVariant { get; set; }
        public float HouseArea { get; set; }
        public float BalconyArea { get; set; }

        public float TerraceArea { get; set; }
        public int NumberOfLivingRoom { get; set; }
        public float HousePrice { get; set; }

        public string HouseModel { get; set; }

        [ForeignKey("House")]
        public int IdHouse { get; set; }

        [Required]
        public virtual House House { get; set; }

        public virtual List<HouseRooms> HouseRooms { get; set;  }
    }
}
