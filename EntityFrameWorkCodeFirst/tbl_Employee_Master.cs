namespace EntityFrameWorkCodeFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Employee_Master
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Employee_Master()
        {
            tbl_Educational_Details = new HashSet<tbl_Educational_Details>();
        }

        [Key]
        public int Employee_Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Employee_Name { get; set; }

        [Required]
        [StringLength(15)]
        public string Contact_No { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        public string Address_Line1 { get; set; }

        [StringLength(100)]
        public string Address_Line2 { get; set; }

        [Required]
        [StringLength(50)]
        public string City { get; set; }

        [Required]
        [StringLength(50)]
        public string State { get; set; }

        [Required]
        [StringLength(50)]
        public string Country { get; set; }

        [Required]
        [StringLength(10)]
        public string Zip_Code { get; set; }

        public bool Active_Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Educational_Details> tbl_Educational_Details { get; set; }
    }
}
