using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Housematica.Data.Data.CMS
{
    public class Single
    {
       
 
        [Key]
        public Guid SingleGuid { get; set; }

        [Required]
        public string Name { get; set; }

        public string Image { get; set; }

        [Required]
        public string NumberOfFloor { get; set; }

        [Required]
        public string Area { get; set; }

    
        public string AreaBuild { get; set; }

      
        public string Price { get; set; }
        public string Status { get; set; }


        [ForeignKey("Projects")]
        public Guid IdProjects { get; set; }

        [Required]
        public virtual Projects Projects { get; set; }

        public virtual List<SingleFloor> SingleFloor { get; set; }



    }
}
