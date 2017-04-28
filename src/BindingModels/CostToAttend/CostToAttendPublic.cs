using System.ComponentModel.DataAnnotations;

namespace UniversityData.BindingModels.CostToAttend
{
    public class CostToAttendPublic
    {
        [Key]
        public int schoolid { get; set; }
        public double pptug_ef { get; set; }
        public int npt4_pub { get; set; }
        public int npt41_pub { get; set; }        
        public int npt42_pub { get; set; }        
        public int npt43_pub { get; set; }        
        public int npt44_pub { get; set; }        
        public int npt45_pub { get; set; }    
    }
}