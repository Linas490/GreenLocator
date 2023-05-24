using System.ComponentModel.DataAnnotations;

namespace GreenLocator.Models
{
    public class Post
    {
        [Key]
        public string Id { get; set; }
        public bool isActive { get; set; }
        public string ApplianceId { get; set; }
        public int Price { get; set; }
        public DateTime PostDate { get; set; }
        public string FullAddress { get; set; } = string.Empty;
        public string ApplianceOwner { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool isReported { get; set; }

        public List<Report> Reports { get; set; }
        public List<Rating> ApplianceRatingList { get; set; }
        public List<Review> Reviews { get; set; }
        public bool UnderMaintenance { get; set; }
    }
}
