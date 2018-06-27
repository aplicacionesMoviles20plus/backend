using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class padreApp

    {
        public int idpadre { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string departamento { get; set; }
        public string provincia { get; set; }
        public string distrito { get; set; }
        public string direccion { get; set; }
        public Nullable<int> celular { get; set; }
        public Nullable<int> dni { get; set; }
        public string fotourl { get; set; }
    }
}