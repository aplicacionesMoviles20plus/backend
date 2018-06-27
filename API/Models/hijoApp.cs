using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class hijoApp
    {
        public int idhijo { get; set; }
        public Nullable<int> id_tutoria { get; set; }
        public Nullable<int> id_padre { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
    }
}