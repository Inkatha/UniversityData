using System.ComponentModel.DataAnnotations;

namespace UniversityData.Models
{
    public class DiversityStatistics
    {
        [Key]
        public int schoolid { get; set; }
        public int ugds { get; set; }
        public double ugds_white { get; set; }
        public double ugds_black { get; set; }
        public double ugds_hisp { get; set; }
        public double ugds_asian { get; set; }
        public double ugds_nhpi { get; set; }
        public double ugds_2mor { get; set; }
        public double ugds_nra { get; set; }
        public double ug25abv { get; set; }
    }
}