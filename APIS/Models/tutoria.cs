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
    
    public partial class tutoria
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tutoria()
        {
            this.avances = new HashSet<avance>();
        }
    
        public int idtutoria { get; set; }
        public string hora { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public Nullable<decimal> precio { get; set; }
        public string comentario { get; set; }
        public Nullable<int> calificacion { get; set; }
        public Nullable<int> id_padre { get; set; }
        public Nullable<int> id_profesor { get; set; }
        public string estado { get; set; }
        public string horafinal { get; set; }
        public string curso { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<avance> avances { get; set; }
        public virtual padre padre { get; set; }
        public virtual profesor profesor { get; set; }
    }
}