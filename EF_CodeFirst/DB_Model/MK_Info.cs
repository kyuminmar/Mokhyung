namespace EF_CodeFirst.DB_Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MK_Info
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MK_Info()
        {
            MK_Info_Box = new HashSet<MK_Info_Box>();
            MK_Info_SP = new HashSet<MK_Info_SP>();
            MK_InOut_Log = new HashSet<MK_InOut_Log>();
            MK_InOut = new HashSet<MK_InOut>();
        }

        [Key]
        public long MI_Seq { get; set; }

        [Required]
        [StringLength(50)]
        public string MI_Name { get; set; }

        [Required]
        [StringLength(2)]
        public string MI_Type { get; set; }

        public int MI_Number { get; set; }

        public int MI_Jang { get; set; }

        public int MI_Pok { get; set; }

        public int MI_Go { get; set; }

        public DateTime MI_RegDate { get; set; }

        public DateTime MI_ModDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MK_Info_Box> MK_Info_Box { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MK_Info_SP> MK_Info_SP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MK_InOut_Log> MK_InOut_Log { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MK_InOut> MK_InOut { get; set; }
    }
}
