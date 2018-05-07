using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIS.Models
{
    public class suscripcionApp
    {
        public int idsuscripcion { get; set; }
        public Nullable<System.DateTime> fechainicio { get; set; }
        public Nullable<System.DateTime> fechafin { get; set; }
        public Nullable<int> id_profesor { get; set; }
    }
}