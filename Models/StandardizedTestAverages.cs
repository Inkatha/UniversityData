using System.ComponentModel.DataAnnotations;

namespace UniversityData.Models
{
    public class StandardizedTestAverages
    {
        [Key]
        public int schoolid { get; set; }
        public int satvr25 { get; set; }
        public int satvr75 { get; set; }
        public int satmt25 { get; set; }
        public int satmt75 { get; set; }
        public int satwr25 { get; set; }
        public int satwr75 { get; set; }
        public int satvrmid { get; set; }
        public int satmtmid { get; set; }
        public int satwrmid { get; set; }
        public int actcm25 { get; set; }
        public int actcm75 { get; set; }
        public int acten25 { get; set; }
        public int acten75 { get; set; }
        public int actmt25 { get; set; }
        public int actmt75 { get; set; }
        public int actwr25 { get; set; }
        public int actwr75 { get; set; }
        public int actcmmid { get; set; }
        public int actenmid { get; set; }
        public int actmtmid { get; set; }
        public int actwrmid { get; set; }
        public int sat_avg { get; set; }
        public int sat_avg_all { get; set; }
    }
}