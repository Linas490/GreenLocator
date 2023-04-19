using System.ComponentModel.DataAnnotations;

namespace GreenLocator.Models
{
    public class Report
    {
        [Key]
        public int ReportId { get; set; }
        public string ApplianceId { get; set; }
        public int UserId { get; set; }
        public String ReportComment { get; set; }
    }
}
