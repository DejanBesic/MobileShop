﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Repository
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
    
        public virtual DbSet<Additional> Additionals { get; set; }
        public virtual DbSet<Administrator> Administrators { get; set; }
        public virtual DbSet<Battery> Batteries { get; set; }
        public virtual DbSet<Camera> Cameras { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Characteristic> Characteristics { get; set; }
        public virtual DbSet<Communication> Communications { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Memory> Memories { get; set; }
        public virtual DbSet<Mobile> Mobiles { get; set; }
        public virtual DbSet<PackageContent> PackageContents { get; set; }
        public virtual DbSet<PhonePlatform> PhonePlatforms { get; set; }
        public virtual DbSet<Screen> Screens { get; set; }
        public virtual DbSet<Shopping> Shoppings { get; set; }
        public virtual DbSet<Sound> Sounds { get; set; }
    }
}
