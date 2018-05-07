using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIS.Models
{
    public class mensajeApp
    {
        public int idmensaje { get; set; }
        public string hora { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public string contenido { get; set; }
        public Nullable<int> id_padre { get; set; }
        public Nullable<int> id_profe { get; set; }
        public string remitente { get; set; }
    }
}