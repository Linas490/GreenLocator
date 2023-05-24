

using System.ComponentModel.DataAnnotations;

namespace GreenLocator.Models
{
    public class Appliance
    {
        [Key]
        public string Id { get; set; }
        public Category Category { get; set; }
        public string ApplianceUserId { get; set; }
        public string Description { get; set; }

        public string Title { get; set; }

        public string ImgUrl { get; set; }

        public int Price { get; set; }

        public static List<Appliance> Appliances = new List<Appliance>();
    }
}
