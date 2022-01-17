using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Housematica.Data.Data.CMS
{
    public class Rooms
    {
        [Key]
        public int IdRoom { get; set; }
        public string RoomName { get; set; }
        public float RoomArea { get; set; }

        [ForeignKey("ApartmentVariants")]
        public int IdApartmentVariants { get; set; }

        [Required]
        public virtual ApartmentVariants ApartmentVariants { get; set; }
    }
}
