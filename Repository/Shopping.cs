//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Shopping
    {
        public int Id { get; set; }
        public Nullable<int> CustomerId { get; set; }
        public Nullable<int> MobileId { get; set; }
        public Nullable<double> Price { get; set; }
        public Nullable<int> ShopId { get; set; }
        public string ShoppingStatus { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual Mobile Mobile { get; set; }
        public virtual Shop Shop { get; set; }
    }
}
