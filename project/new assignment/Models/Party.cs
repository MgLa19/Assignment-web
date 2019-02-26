//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace new_assignment.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Party
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Party()
        {
            this.Menus = new HashSet<Menu>();
            this.Sers = new HashSet<Ser>();
        }
    
        public string id { get; set; }
        public string Description { get; set; }
        public string PartyName { get; set; }
        public string Decoration { get; set; }
        public string image { get; set; }
        public Nullable<decimal> Price_Per_Guest { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Menu> Menus { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ser> Sers { get; set; }
    }
}
