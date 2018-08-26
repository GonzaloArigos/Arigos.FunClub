﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FunClubEntities : DbContext
    {
        public FunClubEntities()
            : base("name=FunClubEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Beneficio> Beneficios { get; set; }
        public virtual DbSet<Beneficio_has_Consumicion> Beneficio_has_Consumicion { get; set; }
        public virtual DbSet<BeneficiosAdquiridosCliente> BeneficiosAdquiridosClientes { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Consumicion> Consumicions { get; set; }
        public virtual DbSet<Consumicion_Bebida> Consumicion_Bebida { get; set; }
        public virtual DbSet<DetallePagoEfectivo> DetallePagoEfectivoes { get; set; }
        public virtual DbSet<DetallePagoTarjetaCredito> DetallePagoTarjetaCreditoes { get; set; }
        public virtual DbSet<DetallePagoTarjetaDebito> DetallePagoTarjetaDebitoes { get; set; }
        public virtual DbSet<DetalleVentaBarra> DetalleVentaBarras { get; set; }
        public virtual DbSet<Discoteca> Discotecas { get; set; }
        public virtual DbSet<Entrada> Entradas { get; set; }
        public virtual DbSet<Entrada_has_Beneficio> Entrada_has_Beneficio { get; set; }
        public virtual DbSet<ListaPreciosConsumicion> ListaPreciosConsumicions { get; set; }
        public virtual DbSet<ListaPreciosEntrada> ListaPreciosEntradas { get; set; }
        public virtual DbSet<Noche> Noches { get; set; }
        public virtual DbSet<Pago> Pagoes { get; set; }
        public virtual DbSet<PrecioConsumicion> PrecioConsumicions { get; set; }
        public virtual DbSet<PrecioEntrada> PrecioEntradas { get; set; }
        public virtual DbSet<Producto> Productoes { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<VentaBarra> VentaBarras { get; set; }
        public virtual DbSet<VentaEntrada> VentaEntradas { get; set; }
    }
}
