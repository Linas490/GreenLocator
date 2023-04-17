namespace GreenLocator.Models
{
    public class User //: AspNetUser
    {
        public int UserId { get; set; }
        public string? email {get; set;}
        public string? City { get; set; }
        public string? Street { get; set; }
        public int? House { get; set; }
        public int? ShareStatus { get; set; }

        public List<Shareable> UserShareables { get; set; } = new List<Shareable>();    

        public User() { }
        
    }
}
