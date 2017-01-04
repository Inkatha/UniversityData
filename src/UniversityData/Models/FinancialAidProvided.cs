using System.ComponentModel.DataAnnotations;

namespace UniversityData.Models
{
    public class FinancialAidProvided
    {
        [Key]
        public int schoolid { get; set; }
        public double pctpell { get; set; }
        public double pctfloan { get; set; }
    }
}