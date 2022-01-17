using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Housematica.Data.Data.CMS
{
    public class HouseRooms { 
        [Key]
        public int IdHouseRoom { get; set; }
        public string RoomName { get; set; }
        public float RoomArea { get; set; }

        [ForeignKey("HouseVariants")]
        public int IdHouseVariants { get; set; }

        [Required]
        public virtual HouseVariants HouseVariants { get; set; }
    }
}
