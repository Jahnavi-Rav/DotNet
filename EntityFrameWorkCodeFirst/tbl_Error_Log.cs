namespace EntityFrameWorkCodeFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Error_Log
    {
        [Key]
        public int Error_Id { get; set; }

        [StringLength(500)]
        public string Page_Name { get; set; }

        [StringLength(500)]
        public string Method_Name { get; set; }

        public string Error_Message { get; set; }

        public string Stack_Trace { get; set; }

        public DateTime? Created_Datetime { get; set; }
    }
}
