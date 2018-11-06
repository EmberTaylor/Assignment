using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace PharmaceuticalsApp.Entities
{
    public partial class SpecialRequirement
    {
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SpecialRequirement()
        {
            Pharmaceuticals = new HashSet<Pharmaceutical>();
        }

        [Key]
        public int SpecialRequirementID { get; set; }

        public int ContainerSize { get; set; }

        [Required]
        [StringLength(20)]
        public string ContainerType { get; set; }

        public bool? StoreInFridge { get; set; }

        public bool? AvailableOverTheCounter { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pharmaceutical> Pharmaceuticals { get; set; }
    }
}
