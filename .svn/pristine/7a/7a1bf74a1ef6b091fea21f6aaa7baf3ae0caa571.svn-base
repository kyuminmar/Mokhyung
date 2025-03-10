namespace EF_CodeFirst.DB_Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MK_Info_Box
    {
        [Key]
        public long MIB_Seq { get; set; }

        public long MI_Seq { get; set; }

        [Required]
        [StringLength(2)]
        public string MIB_Type { get; set; }

        public int MIB_PanNumber { get; set; }

        public int MIB_Pyunglyang { get; set; }

        [StringLength(100)]
        public string MIB_Bigo { get; set; }

        [StringLength(50)]
        public string MIB_FileName { get; set; }

        [StringLength(100)]
        public string MIB_FilePath { get; set; }

        public DateTime MIB_RegDate { get; set; }

        public DateTime MIB_ModDate { get; set; }

        public virtual MK_Info MK_Info { get; set; }
    }
}
