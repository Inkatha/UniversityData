using System.ComponentModel.DataAnnotations;

namespace UniversityData.Models
{
    public class EarningsAfterGraduation
    {
        [Key]
        public int schoolid { get; set; }
        public int md_earn_wane_p10 { get; set; }
        public double gt_25k_p6 { get; set; }
    }
}