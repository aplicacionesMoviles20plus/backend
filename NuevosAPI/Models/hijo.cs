//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NuevosAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class hijo
    {
        public int idhijo { get; set; }
        public Nullable<int> id_tutoria { get; set; }
        public Nullable<int> id_padre { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
    
        public virtual padre padre { get; set; }
        public virtual tutoria tutoria { get; set; }
    }
}