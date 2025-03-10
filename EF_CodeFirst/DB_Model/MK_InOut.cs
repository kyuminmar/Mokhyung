namespace EF_CodeFirst.DB_Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MK_InOut
    {
        [Key]
        public long IO_Seq { get; set; }

        public long SC_Seq { get; set; }

        public long MI_Seq { get; set; }

        public DateTime IO_RegDate { get; set; }

        public virtual MK_Info MK_Info { get; set; }

        public virtual MK_SubContract MK_SubContract { get; set; }
    }
}
