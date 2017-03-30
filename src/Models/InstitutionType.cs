using System.ComponentModel.DataAnnotations;

namespace UniversityData.Models
{
    public class InstitutionType
    {
        [Key]       
        public int schoolid { get; set; }
        public bool hcm2 { get; set; }
        public int locale { get; set; }
        public bool hbcu { get; set; }
        public bool pbi { get; set; }
        public bool annhi { get; set; }
        public bool tribal { get; set; }
        public bool hsi { get; set; }
        public bool nanti { get; set; }
        public bool menonly { get; set; }
        public bool womenonly { get; set; }
        public int relaffil { get; set; }
        public bool distanceonly { get; set; }
        public bool curroper { get; set; }
    }
}