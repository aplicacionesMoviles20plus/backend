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
    
    public partial class horario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public horario()
        {
            this.profesor_horario = new HashSet<profesor_horario>();
        }
    
        public int idhorario { get; set; }
        public string horainicio { get; set; }
        public string horafin { get; set; }
        public string dia { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<profesor_horario> profesor_horario { get; set; }
    }
}
