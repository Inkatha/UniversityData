using System.ComponentModel.DataAnnotations;

namespace UniversityData.Models
{
    public class EarningsAfterGraduation
    {
        [Key]
        public int SchoolID { get; set; }
        public int MD_EARN_WANE_P10 { get; set; }
        public double GT_25K_P6 { get; set; }
    }
}