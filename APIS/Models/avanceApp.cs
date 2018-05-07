using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIS.Models
{
    public class avanceApp
    {
        public int idavance { get; set; }
        public string descripcion { get; set; }
        public Nullable<DateTime> fecha { get; set; }
        public Nullable<int> id_tutoria { get; set; }

    }
}