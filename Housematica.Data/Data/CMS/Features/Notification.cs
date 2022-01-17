using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Housematica.Data.Data.CMS.Features
{
    public class Notification
    {
        [Key]
        public int IdNotifcation { get; set; }

        public string Header { get; set; }

        public string Body { get; set; }

        public string Query { get; set; }

        public string Type { get; set; }
    }
}
