﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Gestión_de_las_Finanzas_Personales
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Sistema_de__Finanzas_PersonalesEntities : DbContext
    {
        public Sistema_de__Finanzas_PersonalesEntities()
            : base("name=Sistema_de__Finanzas_PersonalesEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Gestión_de_Egresos> Gestión_de_Egresos { get; set; }
        public virtual DbSet<Gestion_de_Ingresos> Gestion_de_Ingresos { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Tipos_de_Egresos> Tipos_de_Egresos { get; set; }
        public virtual DbSet<Tipos_de_Ingresos> Tipos_de_Ingresos { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
    }
}
