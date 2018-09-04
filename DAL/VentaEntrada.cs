//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class VentaEntrada
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VentaEntrada()
        {
            this.DetalleVentaEntradas = new HashSet<DetalleVentaEntrada>();
        }
    
        public int CodVentaEntrada { get; set; }
        public int CodDiscoteca { get; set; }
        public int CodPago { get; set; }
        public Nullable<int> Estado { get; set; }
        public Nullable<System.DateTime> FechaAlta { get; set; }
        public string TerminalAlta { get; set; }
        public string UsuarioAlta { get; set; }
        public Nullable<System.DateTime> FechaMod { get; set; }
        public string TerminalMod { get; set; }
        public string UsuarioMod { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleVentaEntrada> DetalleVentaEntradas { get; set; }
        public virtual Discoteca Discoteca { get; set; }
        public virtual Pago Pago { get; set; }
    }
}
