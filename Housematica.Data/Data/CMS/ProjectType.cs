using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Housematica.Data.Data.CMS
{
    public class ProjectType
    {
        [Key]
        public int IdProjectType { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        //Określa jaki layout konfiguracji będzie wyświetlany. Dostępne typy konfiguracji to apartament lub dom
        [Required]
        public string ConfiguratorType { get; set; }

        public virtual ICollection<Projects> Projects { get; set; }

    }
}
