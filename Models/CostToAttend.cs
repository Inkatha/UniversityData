using System.ComponentModel.DataAnnotations;

namespace UniversityData.Models
{
    public class CostToAttend
    {
        [Key]
        public int schoolid { get; set; }
        public double pptug_ef { get; set; }
        public int npt4_pub { get; set; }
        public int npt4_priv { get; set; }        
        public int npt41_pub { get; set; }        
        public int npt42_pub { get; set; }        
        public int npt43_pub { get; set; }        
        public int npt44_pub { get; set; }        
        public int npt45_pub { get; set; }        
        public int npt41_priv { get; set; }        
        public int npt42_priv { get; set; }        
        public int npt43_priv { get; set; }        
        public int npt44_priv { get; set; }        
        public int npt45_priv { get; set; }        
    }
}