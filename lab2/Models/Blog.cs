using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab2.Models
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Please enter a title")]
        public string? Title { get; set; }

        //Relationship
        [ForeignKey("UserId")]
        public User? User { get; set; }
        public int UserId { get; set; }
        public string? Author { get; set; }

        public List<Post>? Posts { get; set; }
    }
}
