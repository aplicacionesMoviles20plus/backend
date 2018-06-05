using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NuevosAPI.Models
{
    public class profesorfavoritoApp
    {
        public int id { get; set; }
        public Nullable<int> id_profesor { get; set; }
        public Nullable<int> id_padre { get; set; }
    }
}