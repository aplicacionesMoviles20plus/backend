using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class servicioApp
    {
        public int idservicio { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public string tipodepago { get; set; }

    }
}