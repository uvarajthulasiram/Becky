//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Becky.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class RestaurantPhoto
    {
        public int Id { get; set; }
        public int RestaurantBranchId { get; set; }
        public int PhotoTypeId { get; set; }
        public string PhotoSource { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual AspNetUser AspNetUser1 { get; set; }
        public virtual LookupPhotoType LookupPhotoType { get; set; }
        public virtual RestaurantBranch RestaurantBranch { get; set; }
    }
}
