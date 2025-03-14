namespace EF_CodeFirst.DB_Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MK_SubContract
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MK_SubContract()
        {
            MK_InOut = new HashSet<MK_InOut>();
            MK_InOut_Log = new HashSet<MK_InOut_Log>();
        }

        [Key]
        public long SC_Seq { get; set; }

        [Required]
        [StringLength(50)]
        public string SC_Name { get; set; }

        [Required]
        [StringLength(50)]
        public string SC_Tel { get; set; }

        [Required]
        [StringLength(100)]
        public string SC_Address { get; set; }

        [StringLength(10)]
        public string SC_Bigo { get; set; }

        public DateTime SC_RegDate { get; set; }

        public DateTime SC_ModDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MK_InOut> MK_InOut { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MK_InOut_Log> MK_InOut_Log { get; set; }

        public virtual MK_SubContract MK_SubContract1 { get; set; }

        public virtual MK_SubContract MK_SubContract2 { get; set; }
    }
}
