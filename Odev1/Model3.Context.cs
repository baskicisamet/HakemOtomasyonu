﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Odev1
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class sporEntities : DbContext
    {
        public sporEntities()
            : base("name=sporEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<hakem> hakem { get; set; }
        public DbSet<lig> lig { get; set; }
        public DbSet<log> log { get; set; }
        public DbSet<sporcu> sporcu { get; set; }
        public DbSet<sporsalonu> sporsalonu { get; set; }
    }
}