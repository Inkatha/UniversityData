using System.ComponentModel.DataAnnotations;

namespace UniversityData.BindingModels.CostToAttend
{
    public class CostToAttendPrivate
    {
        [Key]
        public int schoolid { get; set; }
        public double pptug_ef { get; set; }
        public int npt4_priv { get; set; }        
        public int npt41_priv { get; set; }        
        public int npt42_priv { get; set; }        
        public int npt43_priv { get; set; }        
        public int npt44_priv { get; set; }        
        public int npt45_priv { get; set; }         
    }
}