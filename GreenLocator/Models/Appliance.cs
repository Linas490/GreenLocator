

using System.ComponentModel.DataAnnotations;

namespace GreenLocator.Models
{
    public class Appliance
    {
        [Key]
        public int Id { get; set; }
        public Category Category { get; set; }
        public int ApplianceUserId { get; set; }
        public string Description { get; set; }

        public static List<Appliance> Appliances = new List<Appliance>();
        public Appliance()
        {
            
        }
    }
}
