using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Housematica.Data.Data.CMS
{
    public class SingleRooms
    { 
        [Key]
        public int IdSingleRoom { get; set; }
        public string RoomName { get; set; }
        public float RoomArea { get; set; }

        [ForeignKey("SingleFloor")]
        public int IdSingleFloors { get; set; }

        [Required]
        public virtual SingleFloor SingleFloor { get; set; }
    }
}
