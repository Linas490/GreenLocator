using System.ComponentModel.DataAnnotations;

namespace GreenLocator.Models
{
    public enum ReportCategory
    {
        Harassment,
        [Display(Name = "Hate speech")]
        HateSpeech,
        Spam,
        [Display(Name = "Inappropriate content")]
        InappropriateContent,
        Other
    }
}
