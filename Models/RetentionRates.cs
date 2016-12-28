using System.ComponentModel.DataAnnotations;

namespace UniversityData.Models
{
    public class RetentionRates
    {
        [Key]
        public int SchoolID { get; set; }
        public double RET_FT4 { get; set; }
        public double RET_FTL4 { get; set; }
        public double RET_PT4 { get; set; }
        public double RET_PTL4 { get; set; }
    }
}