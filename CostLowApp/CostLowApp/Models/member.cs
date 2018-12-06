//------------------------------------------------------------------------------
//  Developers: Hunter Hatchette, Kyle Bastson
//  File Name:  member.cs
//  Purpose:    Create a model for members
//  Workload:   We each contributed equally to this.
//------------------------------------------------------------------------------

namespace CostLowApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    //  Member model
    public partial class member
    {
        // For all of the following: Display data annotations are used to correct the name which is displayed for them
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public member()
        {
            this.visits = new HashSet<visit>();
        }
    
        [Display(Name = "Customer ID")]
        public int customerId { get; set; }

        [Display(Name = "Phone Number")]
        public Nullable<long> phoneNumber { get; set; }

        [Display(Name = "First Name")]
        public string firstName { get; set; }

        [Display(Name = "Last Name")]
        public string lastName { get; set; }

        [Display(Name = "Member Status")]
        public Nullable<bool> active { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<visit> visits { get; set; }
    }
}
