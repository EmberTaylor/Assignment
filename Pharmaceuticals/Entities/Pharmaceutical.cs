using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PharmaceuticalsApp.Entities
{
    public partial class Pharmaceutical
    {
        [Key]
        public int PharmaceuticalID { get; set; }

        [ForeignKey(nameof(SpecialRequirement))]
        public int SpecialRequirementID { get; set; }

        [Required]
        [StringLength(50)]
        public string PharmaceuticalName { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; }

        [Required]
        [StringLength(1)]
        public string MedicationType { get; set; }

        public int RecommendedDailyDose { get; set; }

        [Required]
        public virtual SpecialRequirement SpecialRequirement { get; set; }

        [NotMapped]
        //Converts the description and special requirments into a readable format
        public string FormattedDescription
        {
            get
            {
                var sb = new StringBuilder();

                sb.Append($"{Description};{Environment.NewLine}");
                sb.Append($"{GetContainerDescription()};{Environment.NewLine}");

                if (SpecialRequirement.AvailableOverTheCounter == true)
                {
                    sb.Append($"Available over the counter and maybe cheaper;{Environment.NewLine}");
                }

                if (SpecialRequirement.StoreInFridge == true)
                {
                    sb.Append($"MUST BE STORED IN FRIDGE;{Environment.NewLine}");
                }

                return sb.ToString();
            }
        }

        private string GetContainerDescription()
        {
            switch (SpecialRequirement.ContainerType)
            {
                case "Bottle":
                    return $"Comes in a {SpecialRequirement.ContainerSize}{GetMl()} bottle";
                case "Box":
                    return $"Comes in a box of {SpecialRequirement.ContainerSize} tablets";
                case "Phial":
                    return $"Comes in a {SpecialRequirement.ContainerSize}{GetMl()} phial";
                case "Tube":
                    return $"Comes in a {SpecialRequirement.ContainerSize}{GetMl()} tube";
                default:
                    return String.Empty;
            }  
        }

        //checks if a pharmaceutical is messured in ml
        private string GetMl()
        {
            switch (MedicationType)
            {
                case "L": case "O": case "I": case "C":
                    return "ml";
                default:
                    return String.Empty;
            }
        }
    }
}
