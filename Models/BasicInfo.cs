using System.ComponentModel.DataAnnotations;

namespace UniversityData.Model
{
    public class BasicInfo
    {
        [Key]
        public int UnitId { get; set; }
        public int OpeId { get; set; }
        public int OpeId6 { get; set; }
        public string InstitutionName { get; set; }
        public string City { get; set; }
        public string Stabbr { get; set; }
        public string InstitutionUrl { get; set; }
        public string NpCurl { get; set; }
    }
}