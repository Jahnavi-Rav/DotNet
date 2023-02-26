namespace EntityFrameWorkCodeFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_User_Master
    {
        [Key]
        public int User_Id { get; set; }

        [Required]
        [StringLength(500)]
        public string Username { get; set; }

        [Required]
        [StringLength(500)]
        public string Password { get; set; }

        [Required]
        [StringLength(500)]
        public string Full_Name { get; set; }

        public DateTime? Last_Login_Datetime { get; set; }

        public bool Active_Status { get; set; }
    }
}
