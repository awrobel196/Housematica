using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Housematica.Data.Data.CMS
{
    public class House
    {
        [Key]
        public int IdHouse { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string NumberOfFloor { get; set; }

        [Required]
        public string Area { get; set; }

        [ForeignKey("Projects")]
        public Guid IdProjects { get; set; }

        [Required]
        public virtual Projects Projects { get; set; }

        public virtual List<HouseVariants> HouseVariants { get; set; }

        public virtual List<HouseOption> HouseOption { get; set; }

    }
}
