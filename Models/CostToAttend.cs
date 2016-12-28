using System.ComponentModel.DataAnnotations;

namespace UniversityData.Models
{
    public class CostToAttend
    {
        [Key]
        public int SchoolID { get; set; }
        public double PPTUG_EF { get; set; }
        public int NPT4_PUB { get; set; }
        public int NPT4_PRIV { get; set; }        
        public int NPT41_PUB { get; set; }        
        public int NPT42_PUB { get; set; }        
        public int NPT43_PUB { get; set; }        
        public int NPT44_PUB { get; set; }        
        public int NPT45_PUB { get; set; }        
        public int NPT41_PRIV { get; set; }        
        public int NPT42_PRIV { get; set; }        
        public int NPT43_PRIV { get; set; }        
        public int NPT44_PRIV { get; set; }        
        public int NPT45_PRIV { get; set; }        
    }
}