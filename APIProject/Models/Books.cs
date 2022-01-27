using System.ComponentModel.DataAnnotations;

namespace APIProject.Models
{
    public class Books
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        
        public string Author { get; set; }

        public string Description { get; set; }

    }
}
