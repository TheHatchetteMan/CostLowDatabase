//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CostLowApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class employee
    {
        [Display(Name = "Social Security Number")]
        public int ssn { get; set; }

        [Display(Name = "Department ID")]
        public int departmentId { get; set; }

        [Display(Name = "Store Number")]
        public Nullable<int> storeNumber { get; set; }

        [Display(Name = "Phone Number")]
        public Nullable<long> phoneNumber { get; set; }

        [Display(Name = "Salary")]
        public Nullable<decimal> sallary { get; set; }

        [Display(Name = "First Name")]
        public string firstName { get; set; }

        [Display(Name = "Last Name")]
        public string lastName { get; set; }
    
        public virtual department department { get; set; }
    }
}
