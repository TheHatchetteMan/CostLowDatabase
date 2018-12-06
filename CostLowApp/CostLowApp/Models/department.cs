//------------------------------------------------------------------------------
//  Developers: Hunter Hatchette, Kyle Bastson
//  File Name:  department.cs
//  Purpose:    Create a model for departments
//  Workload:   We each contributed equally to this.
//------------------------------------------------------------------------------

namespace CostLowApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    // Department model
    public partial class department
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public department()
        {
            this.employees = new HashSet<employee>();
        }
        
        // For all of the following: Display data annotations are used to correct the name which is displayed for them
        [Display(Name = "Department ID")]
        public int departmentId { get; set; }

        [Display(Name = "Store Number")]
        public int storeNumber { get; set; }

        [Display(Name = "Phone Extension")]
        public Nullable<short> phoneExtension { get; set; }

        [Display(Name = "Department Name")]
        public string departmentName { get; set; }
    
        public virtual store store { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<employee> employees { get; set; }
    }
}
