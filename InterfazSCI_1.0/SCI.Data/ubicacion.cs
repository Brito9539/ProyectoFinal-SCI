//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SCI.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class ubicacion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ubicacion()
        {
            this.proveedor = new HashSet<proveedor>();
        }
    
        public int idUbicacion { get; set; }
        public string Calle { get; set; }
        public string Numero { get; set; }
        public string Cruzamientos { get; set; }
        public string Colonia { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        protected virtual ICollection<proveedor> proveedor { get; set; }
    }
}
