using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NuevosAPI.Models
{
    public class tutoriaApp
    {
        public int idtutoria { get; set; }
        public Nullable<System.TimeSpan> hora { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public Nullable<decimal> precio { get; set; }
        public string comentario { get; set; }
        public Nullable<int> calificacion { get; set; }
        public Nullable<int> id_padre { get; set; }
        public string estado { get; set; }
        public string curso { get; set; }
        public Nullable<int> id_horario { get; set; }
        public Nullable<int> id_servicio { get; set; }
        public Nullable<int> numerohoras { get; set; }

    }
}