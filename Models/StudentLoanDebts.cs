using System.ComponentModel.DataAnnotations;

namespace UniversityData.Models
{
    public class StudentLoanDebts
    {
        [Key]        
        public int schoolid { get; set; }
        public double grad_debt_mdn_supp { get; set; }
        public double grad_debt_mdn10yr_supp { get; set; }
        public double rpy_3yr_rt_supp { get; set; }
    }
}