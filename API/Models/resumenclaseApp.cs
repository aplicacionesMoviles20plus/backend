using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class resumenclaseApp
    {
        public int idresumen { get; set; }
        public string descripcion { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public Nullable<int> id_tutoria { get; set; }

    }
}