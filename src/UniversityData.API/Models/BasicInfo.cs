using System.ComponentModel.DataAnnotations;

namespace UniversityData.Models
{
    public class BasicInfo
    {
        [Key]
        public int unitid { get; set; }
        public int opeid { get; set; }
        public int opeid6 { get; set; }
        public string instnm { get; set; }
        public string city { get; set; }
        public string stabbr { get; set; }
        public string insturl { get; set; }
        public string npcurl { get; set; }
    }
}