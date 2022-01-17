using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Data = Housematica.Data.Data.CMS;

namespace Housematica.Data.Data.CMS
{
    public class User
    {
        [Key]
        public Guid IdUser { get; set; }

        [ForeignKey("License")]
        public Guid IdLicense { get; set; }
        public string name { get; set; }
        public string surname { get; set; }

        public string email { get; set; }

        public string phone { get; set; }
        public string password { get; set; }

        public string avatar { get; set; }

        //Sprawdza czy użytkownik aktywował konto
        public bool isActivate { get; set; }

        public List<ProjectsUser> ProjectsUser { get; set; }

        
        public virtual License License { get; set; }

    }
}
