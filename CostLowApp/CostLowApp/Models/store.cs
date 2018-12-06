//------------------------------------------------------------------------------
//  Developers: Hunter Hatchette, Kyle Bastson
//  File Name:  store.cs
//  Purpose:    Create a model for stores
//  Workload:   We each contributed equally to this.
//------------------------------------------------------------------------------

namespace CostLowApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    //  Store model
    public partial class store
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public store()
        {
            this.departments = new HashSet<department>();
            this.visits = new HashSet<visit>();
        }

        // For all of the following: Display data annotations are used to correct the name which is displayed for them
        [Display(Name = "Store Number")]
        public int storeNumber { get; set; }

        [Display(Name = "Phone Number")]
        public Nullable<long> phoneNumber { get; set; }

        [Display(Name = "Address")]
        public string address { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<department> departments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<visit> visits { get; set; }
    }
}
