//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WcfServiceDemo
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_Employee_Master
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Employee_Master()
        {
            this.tbl_Educational_Details = new HashSet<tbl_Educational_Details>();
        }
    
        public int Employee_Id { get; set; }
        public string Employee_Name { get; set; }
        public string Contact_No { get; set; }
        public string Email { get; set; }
        public string Address_Line1 { get; set; }
        public string Address_Line2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Zip_Code { get; set; }
        public bool Active_Status { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Educational_Details> tbl_Educational_Details { get; set; }
    }
}
