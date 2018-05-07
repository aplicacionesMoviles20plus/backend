using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIS.Models
{
    public class profesor_cursoApp
    {
        public int id { get; set; }
        public Nullable<int> id_profesor { get; set; }
        public Nullable<int> id_curso { get; set; }
    }
}