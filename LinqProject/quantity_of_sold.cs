//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LinqProject
{
    using System;
    using System.Collections.Generic;
    
    public partial class quantity_of_sold
    {
        public int sales_no { get; set; }
        public int item_code { get; set; }
        public int quatity { get; set; }
    
        public virtual sales_invoice sales_invoice { get; set; }
    }
}