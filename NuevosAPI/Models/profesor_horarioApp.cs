using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NuevosAPI.Models
{
    public class profesor_horarioApp
    {
        public int id { get; set; }
        public Nullable<int> id_profesor { get; set; }
        public Nullable<int> id_horario { get; set; }
        public string estado { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
    }
}