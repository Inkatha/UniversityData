using System.ComponentModel.DataAnnotations;

namespace UniversityData.Models
{
    public class CompletionRates
    {
        [Key]
        public int schoolid { get; set; }
        public double c150_4_pooled_supp { get; set; }
        public double c200_l4_pooled_supp { get; set; }
    }
}