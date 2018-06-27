using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class metodopagoApp
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string numerotarjeta { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public string cvv { get; set; }
    }
}