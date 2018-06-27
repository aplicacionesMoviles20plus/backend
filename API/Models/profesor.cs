//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace API.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class profesor
    {
        public profesor()
        {
            this.mensajes = new HashSet<mensaje>();
            this.profesor_cursogrado = new HashSet<profesor_cursogrado>();
            this.profesor_horario = new HashSet<profesor_horario>();
            this.profesor_zona = new HashSet<profesor_zona>();
            this.profesorfavoritoes = new HashSet<profesorfavorito>();
            this.suscripcions = new HashSet<suscripcion>();
        }
    
        public int idprofesor { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string celular { get; set; }
        public string descripcion { get; set; }
        public Nullable<decimal> preciomin { get; set; }
        public Nullable<decimal> preciomax { get; set; }
        public string experiencia { get; set; }
        public Nullable<int> calificacion { get; set; }
        public Nullable<int> dni { get; set; }
        public string antecedentes { get; set; }
        public string fotourl { get; set; }
        public Nullable<int> id_metodopago { get; set; }
    
        public virtual ICollection<mensaje> mensajes { get; set; }
        public virtual metodopago metodopago { get; set; }
        public virtual ICollection<profesor_cursogrado> profesor_cursogrado { get; set; }
        public virtual ICollection<profesor_horario> profesor_horario { get; set; }
        public virtual ICollection<profesor_zona> profesor_zona { get; set; }
        public virtual ICollection<profesorfavorito> profesorfavoritoes { get; set; }
        public virtual ICollection<suscripcion> suscripcions { get; set; }
    }
}