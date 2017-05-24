using System.ComponentModel.DataAnnotations;

namespace UniversityData.BindingModels.StandardizedTesting
{
    public class SatTestAverages
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
        public int sat_avg { get; set; }
        public int sat_avg_all { get; set; }
    }
}