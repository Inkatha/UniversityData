using System.ComponentModel.DataAnnotations;

namespace UniversityData.Models
{
    public class InstitutionType
    {
        [Key]
        public int SchoolID { get; set; }
        public bool HCM2 { get; set; }
        public bool LOCALE { get; set; }
        public bool HBCU { get; set; }
        public bool PBI { get; set; }
        public bool ANNHI { get; set; }
        public bool TRIBAL { get; set; }
        public bool HSI { get; set; }
        public bool NANTI { get; set; }
        public bool MENONLY { get; set; }
        public bool WOMENONLY { get; set; }
        public bool RELAFFIL { get; set; }
        public bool DISTANCEONLY { get; set; }
        public bool CURROPER { get; set; }
    }
}