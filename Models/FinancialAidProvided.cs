using System.ComponentModel.DataAnnotations;

namespace UniversityData.Models
{
    public class FinancialAidProvided
    {
        [Key]
        public int SchoolID { get; set; }
        public double PCTPELL { get; set; }
        public double PCTFLOAN { get; set; }
    }
}