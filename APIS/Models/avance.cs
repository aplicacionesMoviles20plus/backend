//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace APIS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class avance
    {
        public int idavance { get; set; }
        public string descripcion { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public Nullable<int> id_tutoria { get; set; }
    
        public virtual tutoria tutoria { get; set; }
    }
}
