namespace EF_CodeFirst.DB_Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MK_Info_SP
    {
        [Key]
        public long MIS_Seq { get; set; }

        public long MI_Seq { get; set; }

        [Required]
        [StringLength(2)]
        public string MIS_Type { get; set; }

        public bool MIS_JJokYn { get; set; }

        public int MIS_Sangjub { get; set; }

        public int MIS_Hajub { get; set; }

        public int MIS_Pulbari { get; set; }

        [StringLength(100)]
        public string MIS_Bigo { get; set; }

        [StringLength(50)]
        public string MIS_FileName { get; set; }

        [StringLength(100)]
        public string MIS_FilePath { get; set; }

        public DateTime MIS_RegDate { get; set; }

        public DateTime MIS_ModDate { get; set; }

        public virtual MK_Info MK_Info { get; set; }
    }
}
