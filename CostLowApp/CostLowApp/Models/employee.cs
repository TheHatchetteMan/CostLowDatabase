//------------------------------------------------------------------------------
//  Developers: Hunter Hatchette, Kyle Bastson
//  File Name:  employee.cs
//  Purpose:    Create a model for employees
//  Workload:   We each contributed equally to this.
//------------------------------------------------------------------------------

namespace CostLowApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    //  Employee Model
    public partial class employee
    {
        // For all of the following: Display data annotations are used to correct the name which is displayed for them
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
