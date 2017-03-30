using System.ComponentModel.DataAnnotations;

namespace UniversityData.BindingModels 
{
    public class ActTestAverages 
    {
        [Key]
        public int schoolid { get; set; }
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
    }
}