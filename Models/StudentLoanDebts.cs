using System.ComponentModel.DataAnnotations;

namespace UniversityData.Models
{
    public class StudentLoanDebts
    {
        [Key]
        public int SchoolID { get; set; }
        public double GRAD_DEBT_MDN_SUPP { get; set; }
        public double GRAD_DEBT_MDN10YR_SUPP { get; set; }
        public double RPY_3YR_RT_SUPP { get; set; }
    }
}