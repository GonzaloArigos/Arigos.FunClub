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
    
    public partial class DetallePagoTarjetaDebito
    {
        public int CodPagoTarjetaDebito { get; set; }
        public int Pago_CodPago { get; set; }
        public string NumeroDocumento { get; set; }
        public string TarjetaNro { get; set; }
        public Nullable<int> CodigoSeguridad { get; set; }
        public Nullable<System.DateTime> FechaVencimiento { get; set; }
        public Nullable<System.DateTime> FechaAlta { get; set; }
        public string TerminalAlta { get; set; }
        public string UsuarioAlta { get; set; }
        public Nullable<System.DateTime> FechaMod { get; set; }
        public string TerminalMod { get; set; }
        public string UsuarioMod { get; set; }
    
        public virtual Pago Pago { get; set; }
    }
}
