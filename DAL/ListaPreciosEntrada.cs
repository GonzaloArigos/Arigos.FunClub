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
    
    public partial class ListaPreciosEntrada
    {
        public int Entrada_CodEntrada { get; set; }
        public int PrecioEntrada_CodPrecioEntrada { get; set; }
        public Nullable<System.DateTime> FechaAlta { get; set; }
        public string TerminalAlta { get; set; }
        public string UsuarioAlta { get; set; }
        public Nullable<System.DateTime> FechaMod { get; set; }
        public string TerminalMod { get; set; }
        public string UsuarioMod { get; set; }
    
        public virtual Entrada Entrada { get; set; }
        public virtual PrecioEntrada PrecioEntrada { get; set; }
    }
}
