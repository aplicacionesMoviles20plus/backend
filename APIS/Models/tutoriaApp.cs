using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIS.Models
{
    public class tutoriaApp
    {
        public int idtutoria { get; set; }
        public string hora { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public Nullable<decimal> precio { get; set; }
        public string comentario { get; set; }
        public Nullable<int> calificacion { get; set; }
        public Nullable<int> id_padre { get; set; }
        public Nullable<int> id_profesor { get; set; }
        public string estado { get; set; }
        public string horafinal { get; set; }
        public string curso { get; set; }
    }
}