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
    
    public partial class BeneficiosAdquiridosCliente
    {
        public int Beneficio_CodBeneficio { get; set; }
        public int Cliente_CodCliente { get; set; }
        public Nullable<System.DateTime> FechaAdquicicion { get; set; }
        public string Estado { get; set; }
        public Nullable<System.DateTime> FechaAlta { get; set; }
        public string TerminalAlta { get; set; }
        public string UsuarioAlta { get; set; }
        public Nullable<System.DateTime> FechaMod { get; set; }
        public string TerminalMod { get; set; }
        public string UsuarioMod { get; set; }
    
        public virtual Beneficio Beneficio { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}
