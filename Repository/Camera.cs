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
    
    public partial class Camera
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Camera()
        {
            this.Mobiles = new HashSet<Mobile>();
        }
    
        public int Id { get; set; }
        public string BackCamera { get; set; }
        public string BackCameraChar { get; set; }
        public string FrontCamera { get; set; }
        public string FrontCameraChar { get; set; }
        public string Video { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Mobile> Mobiles { get; set; }
    }
}
