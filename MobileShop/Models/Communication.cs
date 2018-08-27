//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Communication
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Communication()
        {
            this.Mobiles = new HashSet<Mobile>();
        }
    
        public int Id { get; set; }
        public string DataTransfer { get; set; }
        public string Network2G { get; set; }
        public string Network3G { get; set; }
        public string Network4G { get; set; }
        public string USB { get; set; }
        public string WiFi { get; set; }
        public string Bluetooth { get; set; }
        public Nullable<bool> NFC { get; set; }
        public Nullable<bool> GPS { get; set; }
        public string PhoneMessages { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Mobile> Mobiles { get; set; }
    }
}