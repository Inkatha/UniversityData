using System.ComponentModel.DataAnnotations;

namespace UniversityData.Models
{
    public class CompletionRates
    {
        [Key]
        public int SchoolID { get; set; }
        public double C150_4_POOLED_SUPP { get; set; }
        public double C200_L4_POOLED_SUPP { get; set; }
    }
}