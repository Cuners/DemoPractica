﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DEmoPrac.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PracticaModeratorEntitie : DbContext
    {
        public PracticaModeratorEntitie()
            : base("name=PracticaModeratorEntitie")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Activnost_meropriyatie> Activnost_meropriyatie { get; set; }
        public virtual DbSet<Activnosti> Activnosti { get; set; }
        public virtual DbSet<Gorod_meropriyatiye> Gorod_meropriyatiye { get; set; }
        public virtual DbSet<Goroda> Goroda { get; set; }
        public virtual DbSet<Meropriatiya> Meropriatiya { get; set; }
        public virtual DbSet<Meropriyatie_juri> Meropriyatie_juri { get; set; }
        public virtual DbSet<Meropriyatiye_tip_Meropriyatiya_napravleniye> Meropriyatiye_tip_Meropriyatiya_napravleniye { get; set; }
        public virtual DbSet<Napravleniya> Napravleniya { get; set; }
        public virtual DbSet<Poli> Poli { get; set; }
        public virtual DbSet<Polzovatel_napravlenie> Polzovatel_napravlenie { get; set; }
        public virtual DbSet<Polzovatel_pol> Polzovatel_pol { get; set; }
        public virtual DbSet<Polzovatel_role> Polzovatel_role { get; set; }
        public virtual DbSet<Polzovateli> Polzovateli { get; set; }
        public virtual DbSet<Polzovateli_meropriatiya> Polzovateli_meropriatiya { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Strani> Strani { get; set; }
        public virtual DbSet<Tipi_meropriatiya> Tipi_meropriatiya { get; set; }
    }
}
