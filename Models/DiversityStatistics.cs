using System.ComponentModel.DataAnnotations;

namespace UniversityData.Models
{
    public class DiversityStatistics
    {
        [Key]
        public int SchoolID { get; set; }
        public int UGDS { get; set; }
        public double UGDS_WHITE { get; set; }
        public double UGDS_BLACK { get; set; }
        public double UGDS_HISP { get; set; }
        public double UGDS_ASIAN { get; set; }
        public double UGDS_NHPI { get; set; }
        public double UGDS_2MOR { get; set; }
        public double UGDS_NRA { get; set; }
        public double UG25ABV { get; set; }
    }
}