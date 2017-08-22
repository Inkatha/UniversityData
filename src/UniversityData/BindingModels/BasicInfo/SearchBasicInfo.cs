using System.ComponentModel.DataAnnotations;

namespace UniversityData.BindingModels.BasicInfo
{
    public class SearchBasicInfo
    {
        [Key]
        public int unitid { get; set; }
        public string instnm { get; set; }
    }
}