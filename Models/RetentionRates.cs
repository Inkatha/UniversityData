using System.ComponentModel.DataAnnotations;

namespace UniversityData.Models
{
    public class RetentionRates
    {
        [Key]
        public int schoolid { get; set; }
        public double ret_ft4 { get; set; }
        public double ret_ftl4 { get; set; }
        public double ret_pt4 { get; set; }
        public double ret_ptl4 { get; set; }
    }
}