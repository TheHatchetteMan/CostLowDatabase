//------------------------------------------------------------------------------
//  Developers: Hunter Hatchette, Kyle Bastson
//  File Name:  visit.cs
//  Purpose:    Create a model for visits
//  Workload:   We each contributed equally to this.
//------------------------------------------------------------------------------

namespace CostLowApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    //  Visit model
    public partial class visit
    {
        // For all of the following: Display data annotations are used to correct the name which is displayed for them
        [Display(Name = "Customer ID")]
        public int customerId { get; set; }

        [Display(Name = "Store Number")]
        public int storeNumber { get; set; }

        [Display(Name = "Date")]
        public System.DateTime date { get; set; }

        [Display(Name = "Amount Spent")]
        public Nullable<decimal> amountSpent { get; set; }
    
        public virtual member member { get; set; }
        public virtual store store { get; set; }
    }
}
