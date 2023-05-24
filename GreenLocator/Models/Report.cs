using System.ComponentModel.DataAnnotations;

namespace GreenLocator.Models
{
    public class Report
    {
        [Key]
        public string ReportId { get; set; }
        public string ApplianceId { get; set; }
        public string UserId { get; set; }
        public String ReportComment { get; set; }
        public ReportCategory ReportCategory { get; set; }
        public ReportStatus ReportStatus { get; set; }
    }
}
