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
    
    public partial class salida
    {
        public int idSalida { get; set; }
        public string USUARIO_Matricula { get; set; }
        public string PRODUCTO_idProducto { get; set; }
        public string USUARIO_Matricula1 { get; set; }
        public Nullable<System.TimeSpan> hora { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public Nullable<double> cantidad { get; set; }
    
        public virtual producto producto { get; set; }
        public virtual usuario usuario { get; set; }
        public virtual usuario usuario1 { get; set; }
    }
}
