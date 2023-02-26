namespace EntityFrameWorkCodeFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Educational_Details
    {
        [Key]
        public int Educational_Details_Id { get; set; }

        public int Employee_Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Education { get; set; }

        [StringLength(500)]
        public string University { get; set; }

        [Required]
        [StringLength(10)]
        public string Grade_Obtained { get; set; }

        [StringLength(10)]
        public string Passing_Year { get; set; }

        public bool Active_Status { get; set; }

        public virtual tbl_Educational_Details tbl_Educational_Details1 { get; set; }

        public virtual tbl_Educational_Details tbl_Educational_Details2 { get; set; }

        public virtual tbl_Employee_Master tbl_Employee_Master { get; set; }
    }
}
