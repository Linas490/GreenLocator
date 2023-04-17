

namespace GreenLocator.Models
{
    public class Shareable
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public string Describtion { get; set; }
        public int Rating { get; set; }

        static List<Shareable> Shareables = new List<Shareable>();
        public Shareable()
        {
            
        }
    }
}
