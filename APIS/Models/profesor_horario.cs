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
    
    public partial class profesor_horario
    {
        public int id { get; set; }
        public Nullable<int> id_profesor { get; set; }
        public Nullable<int> id_horario { get; set; }
    
        public virtual horario horario { get; set; }
        public virtual profesor profesor { get; set; }
    }
}
