
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace GreenLocator.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }

        public Category(int Id, string Title)
        {
            this.Id = Id;
            this.Title = Title;
        }

        public List<Category> categories = new List<Category>() { new Category(0, "Skalbyklė"), new Category(0, "Orkaitė") };
    }
}
