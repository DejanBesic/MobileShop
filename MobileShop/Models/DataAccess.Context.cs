﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MobileShop.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MobileShopEntities : DbContext
    {
        public MobileShopEntities()
            : base("name=MobileShopEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Battery> Batteries { get; set; }
        public virtual DbSet<Camera> Cameras { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Memory> Memories { get; set; }
        public virtual DbSet<Mobile> Mobiles { get; set; }
        public virtual DbSet<OperativeSystem> OperativeSystems { get; set; }
        public virtual DbSet<Proccessor> Proccessors { get; set; }
        public virtual DbSet<RAM> RAMs { get; set; }
        public virtual DbSet<Shop> Shops { get; set; }
        public virtual DbSet<Shop_Mobiles> Shop_Mobiles { get; set; }
        public virtual DbSet<Shopping> Shoppings { get; set; }
    }
}
