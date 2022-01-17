using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Housematica.Data.Data.CMS
{
    public class SingleFloor
    {
        [Key]
        public int IdSingleFloor { get; set; }

        public string FloorName { get; set; }

        //Jeśli jest to rzut zewnętrzny to będzie tu true jeśli jest to rzut kondygnacji to jest to false
        public bool FloorType { get; set; }

        public float FloorArea { get; set; }
        public float BalconyArea { get; set; }

        public float TerraceArea { get; set; }
        public int NumberOfLivingRoom { get; set; }

        public string FloorModel { get; set; }

        public string FloorPlan { get; set; }
        [ForeignKey("Single")]
        public Guid IdSingle { get; set; }

       
        public virtual Single Single { get; set; }

        public virtual List<SingleRooms> SingleRooms { get; set;  }
    }
}
